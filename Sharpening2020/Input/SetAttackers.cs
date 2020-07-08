using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Commands;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Input
{
    class SetAttackers : InputStateBase
    {
        public Boolean IsDone = false;
        public Dictionary<GameAction, CommandBase> ActionCommandMap = new Dictionary<GameAction, CommandBase>();
        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();
            ActionCommandMap.Clear();

            GameAction done = new GameAction(-1, -1, "Done");
            ActionCommandMap.Add(done, null); //Advance to blocking phase.
            res.Add(done);

            int i = 0;
            IEnumerable<Card> availableCreatures = MyGame.GetCards(ZoneType.Battlefield, MyPlayer.Value(MyGame)).Where(x => { return x.CurrentCharacteristics.CardTypes.Contains("Creature"); });
            foreach (Card creat in availableCreatures)
            {
                if(!creat.HasSummoningSickness)
                {
                    IEnumerable<Player> opponents = MyGame.GetPlayers().Where(x => { return x.ID != MyPlayer.ID; });
                    foreach (Player p in opponents)
                    {
                        GameAction gaplayer = new GameAction(i++, creat.ID, "Attack " + p.ToString(MyGame) + "with " + creat.ToString(MyGame));

                        ActionCommandMap.Add(gaplayer, new CommandAddAttacker(creat.ID,p.ID));
                        res.Add(gaplayer);

                        IEnumerable<LazyGameObject<Card>> walkers = p.MyZones[ZoneType.Battlefield].Contents.Where(x => { return x.Value(MyGame).CurrentCharacteristics.CardTypes.Contains("Planeswalker"); });
                        foreach (LazyGameObject<Card> plw in walkers)
                        {
                            GameAction gaplw = new GameAction(i++, creat.ID, "Attack with " + creat.ToString(MyGame));

                            ActionCommandMap.Add(gaplw, new CommandAddAttacker(creat.ID, plw.ID));
                            res.Add(gaplw);
                        }
                    }
                }
            }

            foreach(Card att in MyGame.MyCombatHandler.AttackerToTargetMap.Keys)
            {
                GameAction garem = new GameAction(i++, att.ID, "Remove " + att.ToString(MyGame) + " from attacking.");

                ActionCommandMap.Add(garem, new CommandRemoveAttacker(att.ID));
                res.Add(garem);
            }

            return res;
        }

        public void PromptAndRequestAction()
        {
            MyBridge.Prompt("Select attackers.");
            
            SelectAction(MyBridge.SelectActionFromList(GetActions()));     
        }

        public override void SelectAction(GameAction a)
        {
            if (a.ID == -1)
            {
                IsDone = true;
            }
            else
            {
                MyGame.MyExecutor.Do(ActionCommandMap[a]);
            }

        }

        public override object Clone()
        {
            return new SetAttackers();
        }

        public override string ToString()
        {
            return "SetAttackers";
        }
    }
}
