using System;

using Sharpening2020.Input;
using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandSetAttackingState : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        public CommandSetAttackingState(Int32 p)
        {
            Player = new LazyGameObject<Player>(p);
        }

        public override void Do(Game g)
        {
            sa = new SetAttackers();

            g.InputHandlers[Player.ID].CurrentInputState = sa;
        }

        private SetAttackers sa;

        public override void Undo(Game g)
        {
            g.InputHandlers[Player.ID].RemoveInputFromList(sa);
        }

        public override object Clone()
        {
            return new CommandSetAttackingState(Player.ID);
        }
    }
}
