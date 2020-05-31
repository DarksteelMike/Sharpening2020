using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandDestroy : ICommand
    {
        public readonly Int32 CardID;

        public CommandDestroy(Int32 cid)
        {
            CardID = cid;
        }

        public void Do(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            zt = c.MyZone;

            c.MyZone = ZoneType.Graveyard;
        }

        private ZoneType zt;

        public void Undo(Game g)
        {
            Card c = (Card)g.GameObjects[CardID];

            c.MyZone = zt;
        }
    }
}
