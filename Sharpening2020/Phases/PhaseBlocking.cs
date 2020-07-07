using Sharpening2020.Commands;
using Sharpening2020.Input;
using Sharpening2020.Players;

namespace Sharpening2020.Phases
{
    class PhaseBlocking : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Blocking; } }

        public override bool ShouldGivePriority { get { return false; } }

        public override void DoPhaseEffects(Game g)
        {
            foreach(Player p in g.GetPlayers())
            {
                if(g.ActivePlayer.ID != p.ID)
                {
                    g.MyExecutor.Do(new CommandSetBlockingState(p.ID));
                    SetBlockers sb = (SetBlockers)g.InputHandlers[p.ID].CurrentInputState;
                    while (!sb.IsDone)
                    {
                        sb.PromptAndRequestAction();
                    }

                    g.MyExecutor.Do(new CommandGroup(
                        new CommandRemoveTopInputStates(p.ID),
                        new CommandAdvancePhase()));
                }
            }

            g.MyExecutor.Do(new CommandAdvancePhase());
        }
    }
}
