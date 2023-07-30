using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //For the sake of triggers, this command "sacrifices" a permanent by simply moving it to the graveyard.
    class CommandSacrifice : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> CardID;

        private CommandSacrifice() { }

        public CommandSacrifice(Int32 cid)
        {
            CardID = new LazyGameObject<Card>(cid);
        }

        public override void Do(Game g)
        {
            g.MyExecutor.Do(new CommandMoveCard(CardID.ID, ZoneType.Graveyard));
        }

        public override void Undo(Game g)
        {
            //No undo of this command is necessary as all it's effect is undone by the CommandMoveCard
        }

        public override object Clone()
        {
            return new CommandSacrifice(CardID.ID);
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
