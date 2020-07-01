using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandPerformActionCost : CommandBase
    {
        public readonly LazyGameObject<Card> CardID;
        public readonly Int32 ActivatableIndex;
        public readonly Int32 CostPartIndex;

        public CommandPerformActionCost(Int32 cid, Int32 aind, Int32 cpind)
        {
            CardID = new LazyGameObject<Card>(cid);
            ActivatableIndex = aind;
            CostPartIndex = cpind;
        }

        public override void Do(Game g)
        {
            Card c = CardID.Value(g);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];
            ActionCostPart acp = act.MyCost.ActionParts[CostPartIndex];
            act.MyCost.PaidActions.Add(acp);

            acp.Pay(g);
        }

        public override void Undo(Game g)
        {
            Card c = CardID.Value(g);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];
            ActionCostPart acp = act.MyCost.ActionParts[CostPartIndex];
            act.MyCost.PaidActions.Remove(acp);
            //No need to undo anything more, as the Commands issued by the CostPart's Pay method should already be undone.
        }

        public override object Clone()
        {
            return new CommandPerformActionCost(CardID.ID, ActivatableIndex, CostPartIndex);
        }
    }
}
