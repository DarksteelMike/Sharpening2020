using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

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

        public override void UpdateViews(Game g)
        {
            Int32 OwnerID = ((Card)g.GetGameObjectByID(CardID)).Owner.ID;
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(Origin, OwnerID, g.GetCards(ZoneType.Battlefield).Select(x => { return (CardView)x.GetView(); }).ToList());
                ih.Bridge.UpdateZoneView(Destination, OwnerID, g.GetCards(ZoneType.Graveyard).Select(x => { return (CardView)x.GetView(); }).ToList());
            }
        }
    }
}
