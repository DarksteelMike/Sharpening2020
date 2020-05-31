using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    public class CommandUntap : CommandBase
    {
        public readonly Int32 CardID;

        public CommandUntap(Int32 tgtID)
        {
            CardID = tgtID;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            prevTapState = c.IsTapped;

            c.IsTapped = false;
        }

        private Boolean prevTapState;

        public override void Undo(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            c.IsTapped = prevTapState;
        }

        public override object Clone()
        {
            return new CommandUntap(CardID);
        }
    }
}
