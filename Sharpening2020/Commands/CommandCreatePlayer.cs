using System;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandCreatePlayer : CommandBase
    {
        public override void Do(Game g)
        {
            CreatedPlayer = new Player();
            g.RegisterGameObject(CreatedPlayer);

            CreatedPlayer.Build();
        }

        public Player CreatedPlayer;

        public override void Undo(Game g)
        {
            g.GameObjects.Remove(CreatedPlayer);
        }

        public override object Clone()
        {
            return new CommandCreatePlayer();
        }

    }
}
