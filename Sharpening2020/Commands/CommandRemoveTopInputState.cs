using System;
using System.Linq;

using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandRemoveTopInputState : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandRemoveTopInputState(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            prevState = g.InputHandlers[PlayerID].InputList.Last();
            g.InputHandlers[PlayerID].InputList.Remove(prevState);
            g.InputHandlers[PlayerID].CurrentInputState.Enter();
        }

        private InputStateBase prevState;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].InputList.Add(prevState);
            g.InputHandlers[PlayerID].CurrentInputState.Enter();
        }

        public override object Clone()
        {
            return new CommandRemoveTopInputState(PlayerID);
        }
    }
}
