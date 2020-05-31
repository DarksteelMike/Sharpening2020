using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    public class CommandMoveCard : ICommand
    {
        public readonly ZoneType Origin;
        public readonly ZoneType Destination;
        public readonly Int32 CardID;

        public CommandMoveCard(Int32 cid, ZoneType orig, ZoneType dest)
        {
            CardID = cid;
            Origin = orig;
            Destination = dest;
        }

        public void Do(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            c.MyZone = Destination;
        }

        public void Undo(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            c.MyZone = Origin;
        }
    }
}
