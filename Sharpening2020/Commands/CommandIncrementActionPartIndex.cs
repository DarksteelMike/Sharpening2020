using System;

using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandIncrementActionPartIndex : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;

        public CommandIncrementActionPartIndex(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            PayActionCost pac = (PayActionCost)g.InputHandlers[PlayerID].CurrentInputState;
            pac.ActionPartIndex++;
        }

        public override void Undo(Game g)
        {
            PayActionCost pac = (PayActionCost)g.InputHandlers[PlayerID].CurrentInputState;
            pac.ActionPartIndex--;
        }

        public override object Clone()
        {
            return new CommandIncrementActionPartIndex(PlayerID);
        }

    }
}
