using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandAdvancePhase : CommandBase
    {
        public override void Do(Game g)
        {
            g.MyPhaseHandler.CurrentPhaseIndex++;
        }

        public override void Undo(Game g)
        {
            g.MyPhaseHandler.CurrentPhaseIndex--;
        }

        public override object Clone()
        {
            return new CommandAdvancePhase();
        }
    }
}
