using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command increments the active player index.
    class CommandIncrementActivePlayerIndex : CommandBase
    {
        public override void Do(Game g)
        {
            g.ActivePlayerIndex++;
        }

        public override void Undo(Game g)
        {
            g.ActivePlayerIndex--;
        }

        public override object Clone()
        {
            return new CommandIncrementActivePlayerIndex();
        }
    }
}
