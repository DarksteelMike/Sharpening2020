using System;

using Sharpening2020.Input;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandSetBlockingState : CommandBase
    {
        public readonly LazyGameObject<Player> Player;

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
