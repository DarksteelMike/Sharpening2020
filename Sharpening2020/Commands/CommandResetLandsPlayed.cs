using System;

using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandResetLandsPlayed : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        private CommandResetLandsPlayed() { }

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
