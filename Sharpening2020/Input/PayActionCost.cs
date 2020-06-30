using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;
using Sharpening2020.Mana;

namespace Sharpening2020.Input
{
    class PayActionCost : InputStateBase
    {
        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
       
        public Activatable MyActivatable;
        private Int32 activatableIndex;

        public Int32 ActionPartIndex = 0;

        public PayActionCost(Activatable act)
        {
            MyActivatable = act;
        }

        public override void Enter()
        {
            activatableIndex = MyActivatable.Host.Value(MyGame).CurrentCharacteristics.Activatables.IndexOf(MyActivatable);
            if (MyActivatable.MyCost.AreActionsPaid())
            {
                MoveToManaPayment();
                return;
            }

            PromptAndRequestAction();
        }

        public override void Leave()
        {
            MyGame.MyExecutor.Do(new CommandResetActionCost(MyPlayer.ID));
        }

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();
            ActionCommandPairs.Clear();

            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, null);

            GameAction ok = new GameAction(-1, -1, "OK");
            
            ActionCommandPairs.Add(-1, new CommandPerformActionCost(MyActivatable.Host.ID, activatableIndex, ActionPartIndex));

            res.Add(ok);
            res.Add(cancel);

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            if(a.ID == -2)
            {
                MyGame.MyExecutor.UndoUntilMarker(CommandMarkerType.StartActivating);
                MyGame.EnterAllInputStates();
                return;
            }

            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);

            if(MyActivatable.MyCost.AreActionsPaid())
            {
                MoveToManaPayment();
            }
            else
            {
                MyGame.MyExecutor.Do(new CommandIncrementActionPartIndex(MyPlayer.ID));

                PromptAndRequestAction();
            }
        }

        private void MoveToManaPayment()
        {
            MyGame.MyExecutor.Do(new CommandGroup(new CommandSetPayManaCostState(MyPlayer.ID, MyActivatable.Host.ID, activatableIndex),
                new CommandEnterInputState()));
        }

        public void PromptAndRequestAction()
        {
            MyBridge.Prompt("Perform \"" + MyActivatable.MyCost.ActionParts[ActionPartIndex].ToString(MyGame) + "\"?");
            SelectAction(MyBridge.SelectActionFromList(GetActions()));
        }

        public override object Clone()
        {
            PayActionCost pac = new PayActionCost(MyActivatable);
            pac.ActionPartIndex = this.ActionPartIndex;

            return pac;
        }
    }
}
