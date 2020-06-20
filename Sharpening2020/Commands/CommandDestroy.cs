using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

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
            Card c = (Card)g.GetGameObjectByID(CardID);

            zt = c.MyZone;

            c.MyZone = ZoneType.Graveyard;
        }

        private ZoneType zt;

        public override void Undo(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);

            c.MyZone = zt;
        }

        public override object Clone()
        {
            return new CommandDestroy(CardID);
        }

        public override void UpdateViews(Game g)
        {
            Int32 OwnerID = ((Card)g.GetGameObjectByID(CardID)).Owner.ID;
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(ZoneType.Battlefield, OwnerID, g.GetCards(ZoneType.Battlefield).Select(x => { return (CardView)x.GetView(); }).ToList());
                ih.Bridge.UpdateZoneView(ZoneType.Graveyard, OwnerID, g.GetCards(ZoneType.Graveyard).Select(x => { return (CardView)x.GetView(); }).ToList());
            }
        }
    }
}
