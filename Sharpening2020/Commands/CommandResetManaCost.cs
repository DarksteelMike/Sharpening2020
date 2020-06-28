using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandResetManaCost : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandResetManaCost(Int32 pid)
        {
            PlayerID = pid;
        }
        public override void Do(Game g)
        {
            paidManaParts = new List<ManaCostPart>();

            PayManaCost pmc = (PayManaCost)g.InputHandlers[PlayerID].CurrentInputState; ;
            
            paidManaParts.AddRange(pmc.MyActivatable.MyCost.PaidMana);
            pmc.MyActivatable.MyCost.PaidMana.Clear();
        }
        
        private List<ManaCostPart> paidManaParts;

        public override void Undo(Game g)
        {
            PayManaCost pmc = (PayManaCost)g.InputHandlers[PlayerID].CurrentInputState;

            pmc.MyActivatable.MyCost.PaidMana.Clear();
            pmc.MyActivatable.MyCost.PaidMana.AddRange(paidManaParts);
        }

        public override object Clone()
        {
            return new CommandResetManaCost(PlayerID);
        }
    }
}
