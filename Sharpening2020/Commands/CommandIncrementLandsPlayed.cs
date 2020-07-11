using System;

using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandIncrementLandsPlayed : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        private CommandIncrementLandsPlayed() { }

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
