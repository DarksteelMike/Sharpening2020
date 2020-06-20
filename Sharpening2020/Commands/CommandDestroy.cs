using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Views;
using Sharpening2020.Zones;

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

            Player owner = c.Owner.Value(g);

            orig = g.GetZoneOf(CardID);
            dest = owner.MyZones[ZoneType.Graveyard];

            lgo = orig.Contents.First(x => { return x.ID == CardID; });

            orig.Contents.Remove(lgo);
            dest.Contents.Add(lgo);
        }

        private LazyGameObject<Card> lgo;
        private Zone orig;
        private Zone dest;

        public override void Undo(Game g)
        {
            dest.Contents.Remove(lgo);
            orig.Contents.Add(lgo);
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
                ih.Bridge.UpdateZoneView(ZoneType.Battlefield, OwnerID, g.GetCards(ZoneType.Battlefield).Select(x => { return (CardView)x.GetView(g); }).ToList());
                ih.Bridge.UpdateZoneView(ZoneType.Graveyard, OwnerID, g.GetCards(ZoneType.Graveyard).Select(x => { return (CardView)x.GetView(g); }).ToList());
            }
        }
    }
}
