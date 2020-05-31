using System;

using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    public class CommandSetHavePriorityState : ICommand
    {
        public readonly Int32 PlayerID;
        public CommandSetHavePriorityState(Int32 pid)
        {
            PlayerID = pid;
        }

        public void Do(Game g)
        {
            g.InputHandlers[PlayerID].CurrentInputState = new HavePriority();
        }

        public void Undo(Game g)
        {

        }
    }
}
