using System;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandIncrementLandsPlayed : CommandBase
    {
        public readonly Int32 PlayerID;
        public CommandIncrementLandsPlayed(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);

            p.LandsPlayedThisTurn++;
        }

        public override void Undo(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);

            p.LandsPlayedThisTurn--;
        }

        public override object Clone()
        {
            return new CommandIncrementLandsPlayed(PlayerID);
        }
    }
}
