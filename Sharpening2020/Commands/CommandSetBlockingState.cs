using System;

using Sharpening2020.Input;
using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandSetBlockingState : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        private CommandSetBlockingState() { }

        public CommandSetBlockingState(Int32 p)
        {
            Player = new LazyGameObject<Player>(p);
        }

        public override void Do(Game g)
        {
            sb = new SetBlockers();

            g.InputHandlers[Player.ID].CurrentInputState = sb;
        }

        private SetBlockers sb;

        public override void Undo(Game g)
        {
            g.InputHandlers[Player.ID].RemoveInputFromList(sb);
        }

        public override object Clone()
        {
            return new CommandSetAttackingState(Player.ID);
        }
    }
}
