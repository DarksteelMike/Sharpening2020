using System;

using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandLoseLife : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;
        [ProtoMember(2)]
        public readonly Int32 Amount;

        private CommandLoseLife() { }

        public CommandLoseLife(Int32 pid, Int32 amount)
        {
            Player = new LazyGameObject<Player>(pid);
            Amount = amount;
        }

        public override void Do(Game g)
        {
            Player.Value(g).Life -= Amount;
        }

        public override void Undo(Game g)
        {
            Player.Value(g).Life += Amount;
        }

        public override object Clone()
        {
            return new CommandGainLife(Player.ID, Amount);
        }

        public override void UpdateViews(Game g)
        {
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdatePlayerView((PlayerView)Player.Value(g).GetView(g, ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
