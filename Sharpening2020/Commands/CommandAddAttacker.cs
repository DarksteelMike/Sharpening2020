using System;

using Sharpening2020.Cards;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandAddAttacker : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Attacker;
        [ProtoMember(2)]
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
