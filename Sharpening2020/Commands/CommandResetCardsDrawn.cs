using System;

using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandResetCardsDrawn : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        private CommandResetCardsDrawn() { }

        public CommandResetCardsDrawn(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            Player p = Player.Value(g);
            prevDrawnNum = p.CardsDrawnThisTurn;
            p.CardsDrawnThisTurn = 0;
        }

        private Int32 prevDrawnNum;

        public override void Undo(Game g)
        {
            Player p = Player.Value(g);
            p.CardsDrawnThisTurn = prevDrawnNum;
        }

        public override object Clone()
        {
            return new CommandResetCardsDrawn(Player.ID);
        }
    }
}
