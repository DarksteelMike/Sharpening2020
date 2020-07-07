using System;
using System.Collections.Generic;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandRemoveAttacker : CommandBase
    {
        public readonly LazyGameObject<Card> Attacker;

        public CommandRemoveAttacker(Int32 att)
        {
            Attacker = new LazyGameObject<Card>(att);
        }

        public override void Do(Game g)
        {
            blockers = new List<Card>();
            blockers.AddRange(g.MyCombatHandler.AttackerToBlockersMap[Attacker.Value(g)]);
            g.MyCombatHandler.AttackerToBlockersMap.Remove(Attacker.Value(g));
            icba = g.MyCombatHandler.AttackerToTargetMap[Attacker.Value(g)];
            g.MyCombatHandler.AttackerToTargetMap.Remove(Attacker.Value(g));
        }

        private ICanBeAttacked icba;
        private List<Card> blockers;

        public override void Undo(Game g)
        {
            g.MyCombatHandler.AttackerToBlockersMap.Add(Attacker.Value(g), blockers);
            g.MyCombatHandler.AttackerToTargetMap.Add(Attacker.Value(g), icba);
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
