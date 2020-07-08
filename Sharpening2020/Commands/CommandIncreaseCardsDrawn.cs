using System;

using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandIncreaseCardsDrawn : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        public CommandIncreaseCardsDrawn(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            Player p = Player.Value(g);
            p.CardsDrawnThisTurn++;
        }

        public override void Undo(Game g)
        {
            Player p = Player.Value(g);
            p.CardsDrawnThisTurn--;
        }

        public override object Clone()
        {
            return new CommandIncreaseCardsDrawn(Player.ID);
        }
    }
}
