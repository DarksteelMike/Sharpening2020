﻿using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;

namespace Sharpening2020.Input
{
    class SetTargets : InputStateBase
    {
        public SetTargets(Activatable act)
        {
            MyActivatable = act;
            activatableIndex = MyActivatable.Host.Value(MyGame).CurrentCharacteristics.Activatables.IndexOf(MyActivatable);
        }

        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
        public Activatable MyActivatable;
        private Int32 activatableIndex;

        public override void Enter()
        {
            if (MyActivatable.MyTargeting.IsFinished())
            {
                MoveToActionPayment();
                return;
            }

            PromptAndRequestAction();
        }

        private void MoveToActionPayment()
        {
            MyGame.MyExecutor.Do(new CommandRemoveTopInputState(MyPlayer.ID));
            MyGame.MyExecutor.Do(new CommandSetPayActionCostState(MyPlayer.ID, MyActivatable.Host.ID, activatableIndex));
        }

        public void PromptAndRequestAction()
        {
            MyBridge.Prompt("Select target " + MyActivatable.MyTargeting.Description);
            MyBridge.SelectActionFromList(GetActions());
        }

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();
            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, new CommandRemoveTopInputState(MyPlayer.ID));
            res.Add(cancel);

            Int32 i = 0;
            foreach (GameObject go in MyGame.GameObjects)
            {
                if(MyActivatable.MyTargeting.CanTargetGameObject(MyGame,go) && !MyActivatable.MyTargeting.Targeted.Contains(go))
                {
                    GameAction ga = new GameAction(i, go.ID, "Target " + go.ToString());
                    ActionCommandPairs.Add(i,new CommandAddTarget(MyPlayer.ID,go.ID));
                    res.Add(ga);
                }
            }

            return res;
        }

        public override void SelectAction(GameAction a)
        {
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
            throw new NotImplementedException();
        }
    }
}