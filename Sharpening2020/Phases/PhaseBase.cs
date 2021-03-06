﻿using System;

namespace Sharpening2020.Phases
{
    public enum PhaseType { Untap, Upkeep, Draw, PreCombatMain, BeginCombat, Attacking, Blocking, FirstStrikeDamage, Damage, EndCombat, PostCombatMain, EndOfTurn, Cleanup };
    public abstract class PhaseBase
    {
        public virtual Boolean ShouldGivePriority { get { return true; } }
        public abstract PhaseType MyType { get; }
        public virtual void DoPhaseEffects(Game g) { }
    }
}
