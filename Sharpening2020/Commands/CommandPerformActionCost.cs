using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Costs.ActionCosts;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandPerformActionCost : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> CardID;
        [ProtoMember(2)]
        public readonly Int32 ActivatableIndex;
        [ProtoMember(3)]
        public readonly Int32 CostPartIndex;

        private CommandPerformActionCost() { }

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
