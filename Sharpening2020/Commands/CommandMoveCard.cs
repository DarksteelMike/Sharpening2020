using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020.Commands
{
    public class CommandMoveCard : CommandBase
    {
        public readonly ZoneType Destination;
        public readonly Int32 CardID;

        public CommandMoveCard(Int32 cid, ZoneType dest)
        {
            CardID = cid;
            Destination = dest;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);

            owner = c.Owner.Value(g);
            controller = c.Controller.Value(g);

            orig = g.GetZoneOf(CardID);
            if(Destination != ZoneType.Battlefield && Destination != ZoneType.Exile)
            {
                dest = owner.MyZones[Destination];
            }
            else
            {
                dest = controller.MyZones[Destination];
            }

            lgo = orig.Contents.First(x => { return x.ID == CardID; });

            orig.Contents.Remove(lgo);
            dest.Contents.Add(lgo);
        }

        private Player owner, controller;
        private Zone orig, dest;
        private LazyGameObject<Card> lgo;

        public override void Undo(Game g)
        {
            dest.Contents.Remove(lgo);
            orig.Contents.Add(lgo);
        }

        public override object Clone()
        {
            return new CommandMoveCard(CardID, Destination);
        }

        public override void UpdateViews(Game g)
        {
            Int32 OwnerID = ((Card)g.GetGameObjectByID(CardID)).Owner.ID;
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(orig.MyType, OwnerID, g.GetCards(ZoneType.Battlefield).Select(x => { return (CardView)x.GetView(g); }).ToList());
                ih.Bridge.UpdateZoneView(Destination, OwnerID, g.GetCards(ZoneType.Graveyard).Select(x => { return (CardView)x.GetView(g); }).ToList());
            }
        }
    }
}
