using System;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandIncrementLandsPlayed : CommandBase
    {
        public readonly LazyGameObject<Player> Player;
        public CommandIncrementLandsPlayed(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            Player.Value(g).LandsPlayedThisTurn++;
        }

        public override void Undo(Game g)
        {
            Player.Value(g).LandsPlayedThisTurn--;
        }

        public override object Clone()
        {
            return new CommandIncrementLandsPlayed(Player.ID);
        }
    }
}
