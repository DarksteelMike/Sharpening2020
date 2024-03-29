﻿using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;

namespace Sharpening2020.Input
{
    class SetTargets : InputStateBase
    {
        public SetTargets(Activatable act, AbilityType m)
        {
            MyActivatable = act;
            ActType = m;
        }

        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
        public Activatable MyActivatable;
        public AbilityType ActType;
        private Int32 activatableIndex;

        public override void Enter()
        {
            activatableIndex = MyActivatable.Host.Value(MyGame).CurrentCharacteristics.IndexOfAbility(MyActivatable, ActType);

            if (MyActivatable.MyTargeting.IsFinished())
            {
                MoveToActionPayment();
                return;
            }

            PromptAndRequestAction();
        }

        public override void Leave()
        {
        }

        private void MoveToActionPayment()
        {
            MyGame.MyExecutor.Do(new CommandResetTargets(MyPlayer.ID),
                new CommandSetPayActionCostState(MyPlayer.ID, MyActivatable.Host.ID, activatableIndex, ActType),
                new CommandEnterInputState());
        }

        public void PromptAndRequestAction()
        {
            MyBridge.Prompt("Select target " + MyActivatable.MyTargeting.Targeted.Count.ToString() + " of " + MyActivatable.MyTargeting.MaxTargets + " " + MyActivatable.MyTargeting.Description);
            SelectAction(MyBridge.SelectActionFromList(GetActions()));
        }

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();
            ActionCommandPairs.Clear();
            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, null);
            res.Add(cancel);

            Int32 i = 0;
            foreach (GameObject go in MyGame.GameObjects)
            {
                if(MyActivatable.MyTargeting.CanTargetGameObject(MyGame,go) && !MyActivatable.MyTargeting.Targeted.Contains(go))
                {
                    GameAction ga = new GameAction(i, go.ID, "Target " + go.ToString());
                    ActionCommandPairs.Add(i++,new CommandAddTarget(MyActivatable.Host.ID,activatableIndex,go.ID));
                    res.Add(ga);
                }
            }

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            if (a.ID == -2)
            {
                MyGame.MyExecutor.UndoUntilMarker(CommandMarkerType.StartActivating);
                MyGame.EnterAllInputStates();
                return;
            }

            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);
            if (MyActivatable.MyTargeting.IsFinished())
            {
                MoveToActionPayment();
                return;
            }

            PromptAndRequestAction();
        }

        public override object Clone()
        {
            return new SetTargets(MyActivatable, ActType);
        }

        public override string ToString(Game g)
        {
            return "SetTarget for " + MyActivatable.ToString(g);
        }
    }
}
