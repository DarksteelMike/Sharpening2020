using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandPerformActionCost : CommandBase
    {
        public readonly Int32 CardID;
        public readonly Int32 ActivatableIndex;
        public readonly Int32 CostPartIndex;

        public CommandPerformActionCost(Int32 cid, Int32 aind, Int32 cpind)
        {
            CardID = cid;
            ActivatableIndex = aind;
            CostPartIndex = cpind;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];
            ActionCostPart acp = act.MyCost.ActionParts[CostPartIndex];

            acp.Pay(g);
        }

        public override void Undo(Game g)
        {
            //No need to undo anything, as the Commands issued by the CostPart's Pay method should already be undone.
        }

        public override object Clone()
        {
            return new CommandPerformActionCost(CardID, ActivatableIndex, CostPartIndex);
        }
    }
}
