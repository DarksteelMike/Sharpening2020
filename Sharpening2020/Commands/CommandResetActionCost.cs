using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandResetActionCost : CommandBase
    {
        public readonly Int32 PlayerID;

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
