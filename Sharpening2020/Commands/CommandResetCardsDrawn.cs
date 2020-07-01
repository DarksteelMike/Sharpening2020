using System;

using Sharpening2020.Players;
namespace Sharpening2020.Commands
{
    class CommandResetCardsDrawn : CommandBase
    {
        public readonly LazyGameObject<Player> Player;

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
