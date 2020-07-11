using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandResetManaCost : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;

        private CommandResetManaCost() { }

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
