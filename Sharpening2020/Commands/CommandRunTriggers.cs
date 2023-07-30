using System;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command runs triggers. TODO: Is this even necessary?
    class CommandRunTriggers : CommandBase
    {
        public override void Do(Game g)
        {
            if (g.MyTriggerHandler.WaitingTriggers.Count > 0)
            {
                g.MyTriggerHandler.RunTriggers();
            }
        }

        public override void Undo(Game g)
        {
            //Nothing to do here.
        }

        public override object Clone()
        {
            return new CommandRunTriggers();
        }
    }
}
