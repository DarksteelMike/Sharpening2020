﻿using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

namespace Sharpening2020.Commands
{
    class CommandSetSummoningSickness : CommandBase
    {
        public readonly LazyGameObject<Card> Card;
        public readonly Boolean Mode;

        public CommandSetSummoningSickness(Int32 cid, Boolean m)
        {
            Card = new LazyGameObject<Card>(cid);
            Mode = m;
        }

        public override void Do(Game g)
        {
            prev = Card.Value(g).HasSummoningSickness;
            Card.Value(g).HasSummoningSickness = Mode;
        }

        private Boolean prev;

        public override void Undo(Game g)
        {
            Card.Value(g).HasSummoningSickness = prev;
        }

        public override object Clone()
        {
            return new CommandSetSummoningSickness(Card.ID, Mode);
        }

        public override void UpdateViews(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(Card.ID);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateCardView((CardView)c.GetView(g, ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
