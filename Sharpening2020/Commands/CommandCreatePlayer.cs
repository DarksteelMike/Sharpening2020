using System;

using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command adds a player to the game.
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
