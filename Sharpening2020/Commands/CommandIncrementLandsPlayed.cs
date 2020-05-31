using System;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandIncrementLandsPlayed : ICommand
    {
        public readonly Int32 PlayerID;
        public CommandIncrementLandsPlayed(Int32 pid)
        {
            PlayerID = pid;
        }

        public void Do(Game g)
        {
            Player p = (Player)g.GameObjects[PlayerID];

            p.LandsPlayedThisTurn++;
        }

        public void Undo(Game g)
        {
            Player p = (Player)g.GameObjects[PlayerID];

            p.LandsPlayedThisTurn--;
        }
    }
}
