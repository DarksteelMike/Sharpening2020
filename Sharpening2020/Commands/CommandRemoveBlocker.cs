using System;
using System.Collections.Generic;

using Sharpening2020.Cards;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandRemoveBlocker : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Attacker;
        [ProtoMember(2)]
        public readonly LazyGameObject<Card> Blocker;

        private CommandRemoveBlocker() { }

        public CommandRemoveBlocker(Int32 att, Int32 blo)
        {
            Attacker = new LazyGameObject<Card>(att);
            Blocker = new LazyGameObject<Card>(blo);
        }

        public override void Do(Game g)
        {
            g.MyCombatHandler.AttackerToBlockersMap[Attacker.Value(g)].Remove(Blocker.Value(g));

            if(g.MyCombatHandler.AttackerToBlockersMap[Attacker.Value(g)].Count == 0)
            {
                removedAttacker = true;
                g.MyCombatHandler.AttackerToBlockersMap.Remove(Attacker.Value(g));
            }
        }

        private Boolean removedAttacker = false;

        public override void Undo(Game g)
        {
            if(removedAttacker)
            {
                g.MyCombatHandler.AttackerToBlockersMap.Add(Attacker.Value(g), new List<Card>());
            }

            g.MyCombatHandler.AttackerToBlockersMap[Attacker.Value(g)].Add(Blocker.Value(g));
        }

        public override object Clone()
        {
            return new CommandRemoveBlocker(Attacker.ID, Blocker.ID);
        }
    }
}
