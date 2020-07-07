using Sharpening2020.Commands;

namespace Sharpening2020.Phases
{
    class PhaseAttacking : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Attacking; } }

        public override bool ShouldGivePriority { get { return false; } }

        public override void DoPhaseEffects(Game g)
        {
            g.MyExecutor.Do(new CommandSetAttackingState(g.ActivePlayer.ID));
        }
    }
}
