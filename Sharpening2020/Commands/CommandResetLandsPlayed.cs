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
        public readonly LazyGameObject<Player> Player;

        public CommandResetLandsPlayed(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }
        public override void Do(Game g)
        {
            Player p = Player.Value(g);
            prev = p.LandsPlayedThisTurn;
            p.LandsPlayedThisTurn = 0;
        }

        private Int32 prev;

        public override void Undo(Game g)
        {
            Player p = Player.Value(g);
            p.LandsPlayedThisTurn = prev;
        }

        public override object Clone()
        {
            return new CommandResetLandsPlayed(Player.ID);
        }
    }
}
