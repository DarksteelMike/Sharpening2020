using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandTap : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Card;

        public CommandTap(Int32 tgtID)
        {
            Card = new LazyGameObject<Card>(tgtID);
        }

        public override void Do(Game g)
        {
            Card c = Card.Value(g);

            prevTapState = c.IsTapped;

            c.IsTapped = true;
        }

        private Boolean prevTapState;

        public override void Undo(Game g)
        {
            Card c = Card.Value(g);

            c.IsTapped = prevTapState;
        }

        public override object Clone()
        {
            return new CommandTap(Card.ID);
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
