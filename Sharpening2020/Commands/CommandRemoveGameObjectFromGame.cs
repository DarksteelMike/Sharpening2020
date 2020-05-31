using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandRemoveGameObjectFromGame : CommandBase
    {
        public readonly Int32 goID;

        public CommandRemoveGameObjectFromGame(Int32 id)
        {
            goID = id;
        }

        public override void Do(Game g)
        {
            removedObject = g.GetGameObjectByID(goID);
            g.GameObjects.Remove(removedObject);
        }

        private GameObject removedObject;

        public override void Undo(Game g)
        {
            g.GameObjects.Add(removedObject);
        }

        public override object Clone()
        {
            return new CommandRemoveGameObjectFromGame(goID);
        }
    }
}
