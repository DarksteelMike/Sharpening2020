using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;
using Sharpening2020.Mana;

namespace Sharpening2020.Input
{
    class PayManaCost : InputBase
    {
        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();

        public Cost MyCost;

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();

            GameAction cancel = new GameAction(-2, -2, "Cancel");
            ActionCommandPairs.Add(-2, new CommandRemoveTopInputState(MyPlayer.ID));

            int i = 0;
            foreach(Card c in MyGame.GetCards())
            {
                foreach(Activatable act in c.CurrentCharacteristics.Activatables)
                {
                    if (!(act is Ability))
                        continue;

                    Ability ab = (Ability)act;

                    if (!ab.IsManaAbility)
                        continue;

                    GameAction ga = new GameAction(i++, c.ID, ab.ToString(MyGame));

                    ActionCommandPairs.Add(ga.ID, null);
                }
            }

            foreach(ManaPoint mp in MyPlayer.ManaPool)
            {
                foreach(ManaCostPart mcp in MyCost.ManaParts)
                {
                    if(mp.MyColor == mcp.Color)
                    {
                        GameAction ga = new GameAction(i++, mp.ID, "Pay " + mp.MyColor + "mana for " + mcp.ToString());

                        ActionCommandPairs.Add(ga.ID, null);
                    }
                }
            }

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);
        }

        public override object Clone()
        {
            return new PayManaCost();
        }
    }
}
