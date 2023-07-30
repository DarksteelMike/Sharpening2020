using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command makes a specific player draw a card.
    class CommandDrawCard : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        private CommandDrawCard() { }

        public CommandDrawCard(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            Player p = Player.Value(g);

            if (p.MyZones[ZoneType.Library].Contents.Count == 0)
                return; //TODO: Set a flag to lose the game at next continuous effects check.

            LazyGameObject<Card> TopCard = p.MyZones[ZoneType.Library].Contents[0];

            p.CardsDrawnThisTurn++;

            g.MyExecutor.Do(new CommandSetCardState(TopCard.ID, CharacteristicName.Front),
                            new CommandMoveCard(TopCard.ID, ZoneType.Hand));
        }

        public override void Undo(Game g)
        {
            Player.Value(g).CardsDrawnThisTurn--;
        }

        public override object Clone()
        {
            return new CommandDrawCard(Player.ID);
        }
    }
}
