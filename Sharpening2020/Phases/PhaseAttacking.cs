using Sharpening2020.Commands;
using Sharpening2020.Input;

namespace Sharpening2020.Phases
{
    class PhaseAttacking : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Attacking; } }

        public override bool ShouldGivePriority { get { return false; } }

        public override void DoPhaseEffects(Game g)
        {
            g.MyExecutor.Do(new CommandSetAttackingState(g.ActivePlayer.ID));
            SetAttackers sb = (SetAttackers)g.InputHandlers[g.ActivePlayer.ID].CurrentInputState;
            while (!sb.IsDone)
            {
                sb.PromptAndRequestAction();
            }

            g.MyExecutor.Do(new CommandGroup(
                new CommandRemoveTopInputStates(g.ActivePlayer.ID),
                new CommandAdvancePhase()));
        }
    }
}
