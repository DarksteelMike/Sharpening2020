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
        public readonly LazyGameObject<Card> CardID;

        public CommandMoveCard(Int32 cid, ZoneType dest)
        {
            CardID = new LazyGameObject<Card>(cid);
            Destination = dest;
        }

        public override void Do(Game g)
        {
            Card c = CardID.Value(g);

            Player owner = c.Owner.Value(g);
            Player controller = c.Controller.Value(g);

            orig = g.GetZoneOf(CardID);

            if(Destination == ZoneType.Stack)
            {
                dest = g.StackZone;
            }
            else if(Destination != ZoneType.Battlefield)
            {
                dest = owner.MyZones[Destination];
            }
            else
            {
                dest = controller.MyZones[Destination];
            }

            if(Destination == ZoneType.Battlefield)
            {
                g.MyExecutor.Do(new CommandSetSummoningSickness(CardID.ID, true));
            }

            orig.Contents.Remove(CardID);
            dest.Contents.Add(CardID);
        }
        
        private Zone orig, dest;

        public override void Undo(Game g)
        {
            dest.Contents.Remove(CardID);
            orig.Contents.Add(CardID);
        }

        public override object Clone()
        {
            return new CommandMoveCard(CardID.ID, Destination);
        }

        public override void UpdateViews(Game g)
        {
            Int32 OwnerID = CardID.Value(g).Owner.ID;
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(orig.MyType, OwnerID, orig.Contents.Select(x => { return (CardView)x.Value(g).GetView(g, ih.AssociatedPlayer.Value(g)); }).ToList());
                ih.Bridge.UpdateZoneView(Destination, OwnerID, dest.Contents.Select(x => { return (CardView)x.Value(g).GetView(g, ih.AssociatedPlayer.Value(g)); }).ToList());
            }
        }
    }
}
