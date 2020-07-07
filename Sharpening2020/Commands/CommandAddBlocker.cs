using System;
using System.Collections.Generic;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandAddBlocker : CommandBase
    {
        public readonly LazyGameObject<Card> Blocker;
        public readonly LazyGameObject<Card> Attacker;

        public CommandAddBlocker(Int32 block, Int32 att)
        {
            Blocker = new LazyGameObject<Card>(block);
            Attacker = new LazyGameObject<Card>(att);
        }

        public override void Do(Game g)
        {
            Card att = Attacker.Value(g);
            Card blo = Blocker.Value(g);
            if(!g.MyCombatHandler.AttackerToBlockersMap.ContainsKey(att))
            {
                shouldDeleteOnUndo = true;
                g.MyCombatHandler.AttackerToBlockersMap.Add(att, new List<Card>());
                g.MyCombatHandler.AttackerToBlockersMap[att].Add(blo);
            }
            else
            {
                g.MyCombatHandler.AttackerToBlockersMap[att].Add(blo);
            }
        }

        private Boolean shouldDeleteOnUndo = false;

        public override void Undo(Game g)
        {
            Card att = Attacker.Value(g);
            Card blo = Blocker.Value(g);
            if(shouldDeleteOnUndo)
            {
                g.MyCombatHandler.AttackerToBlockersMap.Remove(att);
            }
            else
            {
                g.MyCombatHandler.AttackerToBlockersMap[att].Remove(blo);
            }
        }

        public override object Clone()
        {
            return new CommandAddBlocker(Blocker.ID, Attacker.ID);
        }

    }
}
