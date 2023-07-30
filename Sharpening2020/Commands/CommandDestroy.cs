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
    //For the sake of triggers, this command destroys a card, basically just moving it to the graveyard.
    class CommandDestroy : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> CardID;

        private CommandDestroy() { }

        public CommandDestroy(Int32 cid)
        {
            CardID = new LazyGameObject<Card>(cid);
        }

        public override void Do(Game g)
        {
            g.MyExecutor.Do(new CommandMoveCard(CardID.ID, ZoneType.Graveyard));
        }

        public override void Undo(Game g)
        {
            //No need to undo anything here, as the move will already have been undone.
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
