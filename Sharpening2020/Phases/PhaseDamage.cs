using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Combat;
using Sharpening2020.Commands;

namespace Sharpening2020.Phases
{
    class PhaseDamage : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Damage; } }

        public override void DoPhaseEffects(Game g)
        {
            CombatHandler ch = g.MyCombatHandler;
            foreach (Card attacker in ch.AttackerToBlockersMap.Keys)
            {
                if (ch.AttackerToBlockersMap[attacker].Count == 0)
                {
                    ICanBeAttacked ICBA = ch.AttackerToTargetMap[attacker];

                    g.MyExecutor.Do(new CommandSetIsTapped(attacker.ID, true));
                    g.MyExecutor.Do(new CommandDealDamage(ICBA.ID, attacker.CurrentCharacteristics.Power));
                }
            }
        }
    }
}
