using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandDestroy : CommandBase
    {
        public readonly Int32 CardID;

        public CommandDestroy(Int32 cid)
        {
            CardID = cid;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            zt = c.MyZone;

            c.MyZone = ZoneType.Graveyard;
        }

        private ZoneType zt;

        public override void Undo(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            c.MyZone = zt;
        }

        public override object Clone()
        {
            return new CommandDestroy(CardID);
        }
    }
}
