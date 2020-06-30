namespace Sharpening2020.Commands
{
    class CommandMarkerGetPriority : CommandBase
    {
        public override void Do(Game g)
        {
            
        }

        public override void Undo(Game g)
        {

        }

        public override object Clone()
        {
            return new CommandMarkerGetPriority();
        }
    }
}
