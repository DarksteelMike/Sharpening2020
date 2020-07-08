using System;

using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandSetHavePriorityState : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;

        public CommandSetHavePriorityState(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            prevState = g.InputHandlers[PlayerID].CurrentInputState;
            g.InputHandlers[PlayerID].CurrentInputState = new HavePriority();
        }

        private InputStateBase prevState;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].CurrentInputState = prevState;
        }

        public override object Clone()
        {
            return new CommandSetHavePriorityState(PlayerID);
        }
    }
}
