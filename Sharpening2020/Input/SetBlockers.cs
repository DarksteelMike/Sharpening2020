using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Commands;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Input
{
    class SetBlockers : InputStateBase
    {
        public Boolean IsDone = false;

        private readonly Dictionary<GameAction, CommandBase> ActionCommandMap = new Dictionary<GameAction, CommandBase>();
        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();
            ActionCommandMap.Clear();

            GameAction done = new GameAction(-1, -1, "Done");
            res.Add(done);

            int i = 0;

            foreach(Card attacker in MyGame.MyCombatHandler.AttackerToTargetMap.Keys)
            {
                ICanBeAttacked icba = MyGame.MyCombatHandler.AttackerToTargetMap[attacker];
                Boolean isAttackingMe = false;
                if (icba is Card)
                {
                    isAttackingMe = ((Card)icba).Controller.ID == MyPlayer.ID;
                }
                else
                {
                    isAttackingMe = ((Player)icba).ID == MyPlayer.ID;
                }

                if(isAttackingMe)
                {
                    IEnumerable<Card> creats = MyGame.GetCards(ZoneType.Battlefield, MyPlayer.Value(MyGame)).Where(x => { return x.CurrentCharacteristics.CardTypes.Contains("Creature"); });
                    foreach(Card c in creats)
                    {
                        if(Utilities.CanBlockAttacker(c,attacker))
                        {
                            GameAction blo = new GameAction(i++, c.ID, "Block " + attacker.ToString(MyGame) + " with this");
                            ActionCommandMap.Add(blo, new CommandAddBlocker(c.ID, attacker.ID));
                            res.Add(blo);
                        }
                    }
                }
            }

            foreach(Card attacker in MyGame.MyCombatHandler.AttackerToBlockersMap.Keys)
            {
                foreach(Card blocker in MyGame.MyCombatHandler.AttackerToBlockersMap[attacker])
                {
                    if(blocker.Controller.ID == MyPlayer.ID)
                    {
                        GameAction blorem = new GameAction(i++, blocker.ID, "Remove " + blocker.ToString(MyGame) + " from blocking.");
                        ActionCommandMap.Add(blorem, new CommandRemoveBlocker(attacker.ID, blocker.ID));
                        res.Add(blorem);
                    }
                }
            }

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            if(a.ID == -1)
            {
                IsDone = true;
            }
            else
            {
                MyGame.MyExecutor.Do(ActionCommandMap[a]);
            }
        }

        public void PromptAndRequestAction()
        {
            MyBridge.Prompt("Select Blockers.");
            SelectAction(MyBridge.SelectActionFromList(GetActions()));
        }

        public override object Clone()
        {
            return new SetBlockers();
        }

        public override string ToString()
        {
            return "SetBlockers";
        }
    }
}
