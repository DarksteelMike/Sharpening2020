using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;
using Sharpening2020.Mana;

namespace Sharpening2020.Input
{
    class PayManaCost : InputStateBase
    {
        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
       
        public Activatable MyActivatable;

        public PayManaCost(Activatable act)
        {
            MyActivatable = act;
        }

        public override void Enter()
        {
            if (MyActivatable.MyCost.IsManaPaid())
            {
                MyGame.MyExecutor.Do(new CommandRemoveTopInputState(MyPlayer.ID));
                MyGame.PlayActivatable(MyActivatable);
            }
        }

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();

            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, new CommandRemoveTopInputState(MyPlayer.ID));

            int i = 0;

            foreach(LazyGameObject<ManaPoint> lmp in MyPlayer.Value(MyGame).ManaPool)
            {
                ManaPoint mp = lmp.Value(MyGame);
                foreach(ManaCostPart mcp in MyActivatable.MyCost.ManaParts)
                {
                    if(mp.MyColor == mcp.Color)
                    {
                        GameAction ga = new GameAction(i++, mp.ID, "Pay " + mp.MyColor + "mana for " + mcp.ToString());

                        ActionCommandPairs.Add(ga.ID, new CommandPayMana(MyPlayer.ID,mp.ID, MyActivatable.MyCost.ManaParts.IndexOf(mcp)));
                    }
                }
            }

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            if(a.ID == -2)
            {
                MyActivatable.MyCost.ClearPaid();
                MyGame.MyExecutor.Do(new CommandRemoveTopInputState(MyPlayer.ID));
            }

            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);

            if(MyActivatable.MyCost.IsManaPaid())
            {
                MyGame.MyExecutor.Do(new CommandRemoveTopInputState(MyPlayer.ID));
                MyGame.PlayActivatable(MyActivatable);
            }

        }

        public override object Clone()
        {
            return new PayManaCost(MyActivatable);
        }
    }
}
