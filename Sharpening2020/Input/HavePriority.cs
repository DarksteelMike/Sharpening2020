using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;

namespace Sharpening2020.Input
{
    class HavePriority : InputBase
    {
        Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
        public override List<GameAction> GetActions()
        {
            List<GameAction> ret = new List<GameAction>();
            GameAction pass = new GameAction(-1, -1, "Pass priority");
            ret.Add(pass);
            ActionCommandPairs.Add(-1, new CommandPassPriority());
            int i = 0;
            foreach(Card c in MyGame.GetCards())
            {
                foreach(Activatable act in c.CurrentCharacteristics.Activatables)
                {
                    if (!act.CanActivate(MyPlayer, MyGame))
                        continue;

                    GameAction a = new GameAction(i++, c.ID, act.ToString(MyGame));

                    //Instead of null, I should add an ICommand that starts off the process of activating the activatable.
                    //Whatever that entails.
                    ActionCommandPairs.Add(a.ID, null);
                    ret.Add(a);
                }

            }
            return ret;
        }

        public override void SelectAction(GameAction a)
        {
            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);
        }

        public override object Clone()
        {
            HavePriority ret = new HavePriority();

            foreach(Int32 ga in ActionCommandPairs.Keys)
            {
                ret.ActionCommandPairs.Add(ga, (CommandBase)ActionCommandPairs[ga].Clone());
            }

            return ret;
        }
    }
}
