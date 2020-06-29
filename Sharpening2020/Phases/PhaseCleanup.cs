using Sharpening2020.Commands;
using Sharpening2020.Players;

namespace Sharpening2020.Phases
{
    class PhaseCleanup : PhaseBase
    {
        public override bool ShouldGivePriority { get { return false; } }
        public override PhaseType MyType { get { return PhaseType.Cleanup; } }
        public override void DoPhaseEffects(Game g)
        {
            foreach (Player p in g.GetPlayers())
            {
                g.MyExecutor.Do(new CommandGroup(new CommandResetCardsDrawn(p.ID),
                    new CommandResetLandsPlayed(p.ID)));
            }

            if(g.MyContinuousEffects.StaticEffects.Count > 0)
                g.MyExecutor.Do(new CommandClearStaticContinuousEffects());

            g.MyExecutor.Do(new CommandIncrementActivePlayerIndex());
        }
    }
}
