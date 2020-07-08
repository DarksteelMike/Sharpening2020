using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Views;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandDestroy : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> CardID;

        public CommandDestroy(Int32 cid)
        {
            CardID = new LazyGameObject<Card>(cid);
        }

        public override void Do(Game g)
        {
            Card c = CardID.Value(g);

            Player owner = c.Owner.Value(g);

            Zone orig = g.GetZoneOf(CardID);
            Zone dest = owner.MyZones[ZoneType.Graveyard];

            orig.Contents.Remove(CardID);
            dest.Contents.Add(CardID);
        }

        public override void Undo(Game g)
        {
            Zone orig = g.GetZoneOf(CardID);
            Zone dest = CardID.Value(g).Owner.Value(g).MyZones[ZoneType.Graveyard];

            dest.Contents.Remove(CardID);
            orig.Contents.Add(CardID);
        }

        public override object Clone()
        {
            return new CommandDestroy(CardID.ID);
        }

        public override void UpdateViews(Game g)
        {
            Int32 OwnerID = CardID.Value(g).Owner.ID;
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(ZoneType.Battlefield, OwnerID, g.GetCards(ZoneType.Battlefield).Select(x => { return (CardView)x.GetView(g, ih.AssociatedPlayer.Value(g)); }).ToList());
                ih.Bridge.UpdateZoneView(ZoneType.Graveyard, OwnerID, g.GetCards(ZoneType.Graveyard).Select(x => { return (CardView)x.GetView(g, ih.AssociatedPlayer.Value(g)); }).ToList());
            }
        }
    }
}
