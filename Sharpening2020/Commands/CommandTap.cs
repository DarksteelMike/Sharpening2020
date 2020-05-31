﻿using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    public class CommandTap : ICommand
    {
        public readonly Int32 CardID;

        public CommandTap(Int32 tgtID)
        {
            CardID = tgtID;
        }

        public void Do(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            prevTapState = c.IsTapped;

            c.IsTapped = true;
        }

        private Boolean prevTapState;

        public void Undo(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            c.IsTapped = prevTapState;
        }
    }
}
