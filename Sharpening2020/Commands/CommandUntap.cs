using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

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
            Card c = (Card)g.GetGameObjectByID(CardID);

            prevTapState = c.IsTapped;

            c.IsTapped = false;
        }

        private Boolean prevTapState;

        public override void Undo(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);

            c.IsTapped = prevTapState;
        }

        public override object Clone()
        {
            return new CommandUntap(CardID);
        }

        public override void UpdateViews(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateCardView((CardView)c.GetView(g));
            }
        }
    }
}
