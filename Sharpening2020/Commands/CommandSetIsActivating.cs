using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Commands
{
    class CommandSetIsActivating : CommandBase
    {
        public readonly LazyGameObject<Card> Card;
        public readonly Int32 ActivatableIndex;
        public readonly Boolean Mode;

        public CommandSetIsActivating(Int32 cid, Int32 aind, Boolean m)
        {
            Card = new LazyGameObject<Card>(cid);
            ActivatableIndex = aind;
            Mode = m;
        }

        public override void Do(Game g)
        {
            prev = Card.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex].IsBeingActivated;
            Card.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex].IsBeingActivated = Mode;
        }

        private Boolean prev = true;

        public override void Undo(Game g)
        {
            Card.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex].IsBeingActivated = prev;
        }

        public override object Clone()
        {
            return new CommandSetIsActivating(Card.ID, ActivatableIndex, Mode);
        }
    }
}
