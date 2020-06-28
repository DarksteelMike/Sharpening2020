using Sharpening2020.Commands;
using Sharpening2020.Players;

namespace Sharpening2020.Phases
{
    class PhaseCleanup : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Cleanup; } }
        public override void PhaseEffects(Game g)
        {
            foreach (Player p in g.GetPlayers())
            {
                g.MyExecutor.Do(new CommandGroup(new CommandResetCardsDrawn(p.ID),
                    new CommandResetLandsPlayed(p.ID)));
            }

            g.MyExecutor.Do(new CommandIncrementActivePlayerIndex());
        }
    }
}
