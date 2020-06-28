using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandResetLandsPlayed : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandResetLandsPlayed(Int32 pid)
        {
            PlayerID = pid;
        }
        public override void Do(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            prev = p.LandsPlayedThisTurn;
            p.LandsPlayedThisTurn = 0;
        }

        private Int32 prev;

        public override void Undo(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            p.LandsPlayedThisTurn = prev;
        }

        public override object Clone()
        {
            return new CommandResetLandsPlayed(PlayerID);
        }
    }
}
