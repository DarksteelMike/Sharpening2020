using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandSetIsTapped : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Card;
        [ProtoMember(2)]
        public readonly Boolean Mode;

        public CommandSetIsTapped(Int32 tgtID, Boolean m)
        {
            Card = new LazyGameObject<Card>(tgtID);
            Mode = m;
        }

        public override void Do(Game g)
        {
            Card c = Card.Value(g);

            prevTapState = c.IsTapped;

            c.IsTapped = Mode;
        }

        private Boolean prevTapState;

        public override void Undo(Game g)
        {
            Card c = Card.Value(g);

            c.IsTapped = prevTapState;
        }

        public override object Clone()
        {
            return new CommandSetIsTapped(Card.ID, Mode);
        }

        public override void UpdateViews(Game g)
        {
            Card c = Card.Value(g);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateCardView((CardView)c.GetView(g, ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
