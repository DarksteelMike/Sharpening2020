using System;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command passes priority to the next player.
    public class CommandPassPriority : CommandBase
    {
        public override void Do(Game g)
        {
            g.PlayersPassedInSuccession++;
            g.PlayerWithPriorityIndex++;            
        }

        public override void Undo(Game g)
        {
            g.PlayersPassedInSuccession--;
            g.PlayerWithPriorityIndex--;
        }

        public override object Clone()
        {
            return new CommandPassPriority();
        }
    }
}
