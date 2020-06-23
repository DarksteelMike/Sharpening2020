using System;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandIncreaseCardsDrawn : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandIncreaseCardsDrawn(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            p.CardsDrawnThisTurn++;
        }

        public override void Undo(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            p.CardsDrawnThisTurn--;
        }

        public override object Clone()
        {
            return new CommandIncreaseCardsDrawn(PlayerID);
        }
    }
}
