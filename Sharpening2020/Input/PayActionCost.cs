using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;
using Sharpening2020.Mana;

namespace Sharpening2020.Input
{
    class PayActionCost : InputBase
    {
        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
       
        public Activatable MyActivatable;

        public override void Reset()
        {
            MyActivatable.MyCost.ClearPaid();
        }

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();

            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, new CommandRemoveTopInputState(MyPlayer.ID));

            int i = 0;

            foreach(ManaPoint mp in MyPlayer.ManaPool)
            {
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
            }

            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);

            if(MyActivatable.MyCost.IsPaid())
            {
                MyGame.PlayActivatable(MyActivatable);
            }

        }

        public override object Clone()
        {
            return new PayManaCost();
        }
    }
}
