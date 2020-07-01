using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandSetCardState : CommandBase
    {
        public readonly LazyGameObject<Card> Card;
        public readonly CharacteristicName NewState;

        public CommandSetCardState(Int32 cid, CharacteristicName st)
        {
            Card = new LazyGameObject<Card>(cid);
            NewState = st;
        }

        public override void Do(Game g)
        {
            Card c = Card.Value(g);

            oldState = c.CurrentCharacteristicName;
            c.CurrentCharacteristicName = NewState;
        }

        private CharacteristicName oldState;

        public override void Undo(Game g)
        {
            Card c = Card.Value(g);
            c.CurrentCharacteristicName = oldState;
        }

        public override object Clone()
        {
            return new CommandSetCardState(Card.ID, NewState);
        }
    }
}
