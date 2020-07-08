using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandUntap : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Card;

        public CommandUntap(Int32 tgtID)
        {
            Card = new LazyGameObject<Card>(tgtID);
        }

        public override void Do(Game g)
        {
            Card c = Card.Value(g);

            prevTapState = c.IsTapped;

            c.IsTapped = false;
        }

        private Boolean prevTapState;

        public override void Undo(Game g)
        {
            Card c = Card.Value(g);

            c.IsTapped = prevTapState;
        }

        public override object Clone()
        {
            return new CommandUntap(Card.ID);
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
