using System;
using System.Collections.Generic;

using Sharpening2020.Input;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandClearInputList : CommandBase
    {
        public readonly LazyGameObject<Player> Player;

        public CommandClearInputList(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            prev = new List<InputStateBase>();

            prev.AddRange(g.InputHandlers[Player.ID].InputList);

            g.InputHandlers[Player.ID].InputList.Clear();
        }

        private List<InputStateBase> prev;

        public override void Undo(Game g)
        {
            g.InputHandlers[Player.ID].InputList.AddRange(prev);
        }

        public override object Clone()
        {
            return new CommandClearInputList(Player.ID);
        }
    }
}
