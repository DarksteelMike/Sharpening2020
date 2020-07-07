using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    public class CommandAddAttacker : CommandBase
    {
        public readonly LazyGameObject<Card> Attacker;
        public readonly Int32 Defender;
        public CommandAddAttacker(Int32 att, Int32 def)
        {
            Attacker = new LazyGameObject<Card>(att);
            Defender = def;
        }

        public override void Do(Game g)
        {
            Card att = Attacker.Value(g);
            ICanBeAttacked ICBA = (ICanBeAttacked)g.GetGameObjectByID(Defender);
            if(g.MyCombatHandler.AttackerToTargetMap.ContainsKey(att))
            {
                prev = g.MyCombatHandler.AttackerToTargetMap[att];
                g.MyCombatHandler.AttackerToTargetMap[att] = ICBA;
            }
            else
            {
                g.MyCombatHandler.AttackerToTargetMap.Add(att, ICBA);
            }
        }

        private ICanBeAttacked prev = null;

        public override void Undo(Game g)
        {
            Card att = Attacker.Value(g);
            if(prev != null)
            {
                g.MyCombatHandler.AttackerToTargetMap[att] = prev;
            }
            else
            {
                g.MyCombatHandler.AttackerToTargetMap.Remove(att);
            }
        }

        public override object Clone()
        {
            return new CommandAddAttacker(Attacker.ID, Defender);
        }
    }
}
