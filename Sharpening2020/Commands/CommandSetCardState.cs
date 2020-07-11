using System;

using Sharpening2020.Cards;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandSetCardState : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Card;
        [ProtoMember(2)]
        public readonly CharacteristicName NewState;

        private CommandSetCardState() { }

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
