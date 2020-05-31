using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandRemoveGameObjectFromGame : ICommand
    {
        public readonly Int32 goID;

        public CommandRemoveGameObjectFromGame(Int32 id)
        {
            goID = id;
        }

        public void Do(Game g)
        {
            token = g.GetGameObjectByID(goID);
            g.GameObjects.Remove(token);
        }

        private GameObject token;

        public void Undo(Game g)
        {
            g.GameObjects.Add(token);
        }
    }
}
