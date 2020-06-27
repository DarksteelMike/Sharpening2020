using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandResetCost : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandResetCost(Int32 pid)
        {
            PlayerID = pid;
        }
        public override void Do(Game g)
        {
            InputStateBase isb = g.InputHandlers[PlayerID].CurrentInputState;
            paidActionParts = new List<ActionCostPart>();
            paidManaParts = new List<ManaCostPart>();

            if(isb is PayActionCost)
            {
                PayActionCost pac = (PayActionCost)isb;

                paidActionParts.AddRange(pac.MyActivatable.MyCost.PaidActions);
                pac.MyActivatable.MyCost.ClearPaid();
            }
            else if(isb is PayManaCost)
            {
                PayManaCost pmc = (PayManaCost)isb;

                paidActionParts.AddRange(pmc.MyActivatable.MyCost.PaidActions);
                paidManaParts.AddRange(pmc.MyActivatable.MyCost.PaidMana);
                pmc.MyActivatable.MyCost.ClearPaid();
            }
        }

        private List<ActionCostPart> paidActionParts;
        private List<ManaCostPart> paidManaParts;

        public override void Undo(Game g)
        {
            InputStateBase isb = g.InputHandlers[PlayerID].CurrentInputState;
            paidActionParts = new List<ActionCostPart>();
            paidManaParts = new List<ManaCostPart>();

            if (isb is PayActionCost)
            {
                PayActionCost pac = (PayActionCost)isb;
                pac.MyActivatable.MyCost.PaidActions.Clear();
                pac.MyActivatable.MyCost.PaidActions.AddRange(paidActionParts);
            }
            else if (isb is PayManaCost)
            {
                PayManaCost pmc = (PayManaCost)isb;

                pmc.MyActivatable.MyCost.PaidActions.Clear();
                pmc.MyActivatable.MyCost.PaidActions.AddRange(paidActionParts);
                pmc.MyActivatable.MyCost.PaidMana.Clear();
                pmc.MyActivatable.MyCost.PaidMana.AddRange(paidManaParts);
            }
        }

        public override object Clone()
        {
            return new CommandResetCost(PlayerID);
        }
    }
}
