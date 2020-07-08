using System;

using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [Serializable]
    class CommandSetWaitingForOpponentsState : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandSetWaitingForOpponentsState(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            prevState = g.InputHandlers[PlayerID].CurrentInputState;

            g.InputHandlers[PlayerID].CurrentInputState = new WaitingForOpponent();
        }

        private InputStateBase prevState;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].CurrentInputState = prevState;
        }

        public override object Clone()
        {
            return new CommandSetWaitingForOpponentsState(PlayerID);
        }
    }
}
