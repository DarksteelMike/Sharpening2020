using System;

using Sharpening2020.Players;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandSetWaitingForOpponentsState : ICommand
    {
        public readonly Int32 PlayerID;

        public CommandSetWaitingForOpponentsState(Int32 pid)
        {
            PlayerID = pid;
        }

        public void Do(Game g)
        {
            prevState = g.InputHandlers[PlayerID].CurrentInputState;

            g.InputHandlers[PlayerID].CurrentInputState = new WaitingForOpponent();
        }

        private InputBase prevState;

        public void Undo(Game g)
        {
            g.InputHandlers[PlayerID].CurrentInputState = prevState;
        }
    }
}
