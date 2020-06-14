using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    public class CommandMoveCard : CommandBase
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

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);

            c.MyZone = Destination;
        }

        public override void Undo(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);

            c.MyZone = Origin;
        }

        public override object Clone()
        {
            return new CommandMoveCard(CardID, Origin, Destination);
        }
    }
}
