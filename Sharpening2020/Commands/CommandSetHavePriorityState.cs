using System;

using Sharpening2020.Attributes;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    public class CommandSetHavePriorityState : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;

        private CommandSetHavePriorityState() { }

        public CommandSetHavePriorityState(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            if(g.InputHandlers.ContainsKey(PlayerID))
            {
                prevState = g.InputHandlers[PlayerID].CurrentInputState;
                g.InputHandlers[PlayerID].CurrentInputState = new HavePriority();
            }
        }

        private InputStateBase prevState = null;

        public override void Undo(Game g)
        {
            if(prevState != null)
            {

                g.InputHandlers[PlayerID].CurrentInputState = prevState;
            }
        }

        public override object Clone()
        {
            return new CommandSetHavePriorityState(PlayerID);
        }
    }
}
