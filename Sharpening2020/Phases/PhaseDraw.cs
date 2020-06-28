using Sharpening2020.Commands;

namespace Sharpening2020.Phases
{
    public class PhaseDraw : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Draw; } }
        public override void PhaseEffects(Game g)
        {
            g.MyExecutor.Do(new CommandDrawCard(g.ActivePlayer.ID));
        }
    }
}
