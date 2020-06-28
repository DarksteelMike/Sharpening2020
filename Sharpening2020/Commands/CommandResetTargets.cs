using System;

using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandResetTargets : CommandBase
    {
        public Int32 PlayerID;

        public CommandResetTargets(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            InputStateBase isb = g.InputHandlers[PlayerID].CurrentInputState;
            
        }

        public override void Undo(Game g)
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
