using Sharpening2020.Commands;

namespace Sharpening2020.Phases
{
    public class PhaseDraw : PhaseBase
    {
        public override bool ShouldGivePriority { get { return false; } }
        public override PhaseType MyType { get { return PhaseType.Draw; } }
        public override void DoPhaseEffects(Game g)
        {
            g.MyExecutor.Do(new CommandDrawCard(g.ActivePlayer.ID));
        }
    }
}
