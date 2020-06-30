using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

namespace Sharpening2020.Commands
{
    class CommandSetSummoningSickness : CommandBase
    {
        public readonly Int32 CardID;
        public readonly Boolean Mode;

        public CommandSetSummoningSickness(Int32 cid, Boolean m)
        {
            CardID = cid;
            Mode = m;
        }

        public override void Do(Game g)
        {
            ((Card)g.GetGameObjectByID(CardID)).HasSummoningSickness = Mode;
        }

        public override void Undo(Game g)
        {
            ((Card)g.GetGameObjectByID(CardID)).HasSummoningSickness = !Mode;
        }

        public override object Clone()
        {
            return new CommandSetSummoningSickness(CardID, Mode);
        }

        public override void UpdateViews(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateCardView((CardView)c.GetView(g, ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
