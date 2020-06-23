using System;

using Sharpening2020.Players;
namespace Sharpening2020.Commands
{
    class CommandResetCardsDrawn : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandResetCardsDrawn(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            prevDrawnNum = p.CardsDrawnThisTurn;
            p.CardsDrawnThisTurn = 0;
        }

        private Int32 prevDrawnNum;

        public override void Undo(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            p.CardsDrawnThisTurn = prevDrawnNum;
        }

        public override object Clone()
        {
            return new CommandResetCardsDrawn(PlayerID);
        }
    }
}
