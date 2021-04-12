using System;
using System.Collections.Generic;

using Sharpening2020.Attributes;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    class CommandResetActionCost : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;

        private CommandResetActionCost() { }

        public CommandResetActionCost(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            paidActionParts = new List<ActionCostPart>();
            PayActionCost pac = (PayActionCost)g.InputHandlers[PlayerID].CurrentInputState;

            paidActionParts.AddRange(pac.MyActivatable.MyCost.PaidActions);
            pac.MyActivatable.MyCost.PaidActions.Clear();
        }

        private List<ActionCostPart> paidActionParts;

        public override void Undo(Game g)
        {
            PayActionCost pac = (PayActionCost)g.InputHandlers[PlayerID].CurrentInputState;

            pac.MyActivatable.MyCost.PaidActions.Clear();
            pac.MyActivatable.MyCost.PaidActions.AddRange(paidActionParts);
        }

        public override object Clone()
        {
            return new CommandResetActionCost(PlayerID);
        }
    }
}
