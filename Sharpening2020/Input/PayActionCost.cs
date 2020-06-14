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
            activatableIndex = MyActivatable.Host.Value(MyGame).CurrentCharacteristics.Activatables.IndexOf(MyActivatable);
        }

        public override void Leave()
        {
            MyActivatable.MyCost.PaidActions.Clear();
        }

        

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();

            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, new CommandRemoveTopInputState(MyPlayer.ID));

            GameAction ok = new GameAction(-1, -1, "OK");
            
            ActionCommandPairs.Add(-1, new CommandPerformActionCost(MyActivatable.Host.ID, activatableIndex, ActionPartIndex));

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            if(a.ID == -2)
            {
                MyActivatable.MyCost.ClearPaid();
                //TODO: Cancel out.
            }

            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);

            if(MyActivatable.MyCost.AreActionsPaid())
            {
                MyGame.MyExecutor.Do(new CommandRemoveTopInputState(MyPlayer.ID));
                MyGame.MyExecutor.Do(new CommandSetPayManaCostState(MyPlayer.ID, MyActivatable.Host.ID, activatableIndex));
            }
            else
            {
                MyGame.MyExecutor.Do(new CommandIncrementActionPartIndex(MyPlayer.ID));
            }
        }

        public override object Clone()
        {
            return new PayActionCost(MyActivatable);
        }
    }
}
