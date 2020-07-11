using System;

using Sharpening2020.Cards;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandRemoveGameObjectFromGame : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 goID;

        private CommandRemoveGameObjectFromGame() { }

        public CommandRemoveGameObjectFromGame(Int32 id)
        {
            goID = id;
        }

        public override void Do(Game g)
        {
            removedObject = g.GetGameObjectByID(goID);
            g.GameObjects.Remove(removedObject);

            if(removedObject is Card)
            {
                removedFrom = g.GetZoneOf((Card)removedObject);
                removedFrom.Contents.RemoveAll(x => { return x.ID == removedObject.ID; });
            }
        }

        private GameObject removedObject;
        private Zone removedFrom;

        public override void Undo(Game g)
        {
            g.GameObjects.Add(removedObject);
            removedFrom.Contents.Add(new LazyGameObject<Card>(removedObject.ID));
        }

        public override object Clone()
        {
            return new CommandRemoveGameObjectFromGame(goID);
        }
    }
}
