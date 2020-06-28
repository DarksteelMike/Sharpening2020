using System;

namespace Sharpening2020.Phases
{
    public enum PhaseType { Untap, Upkeep, Draw, PreCombatMain, PostCombatMain, EndOfTurn, Cleanup };
    public abstract class PhaseBase
    {
        public abstract PhaseType MyType { get; }
        public virtual void PhaseEffects(Game g) { }
    }
}
