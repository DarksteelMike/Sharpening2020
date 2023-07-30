using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command removes a game object from the game and the zone it occupies if applicable.
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
            removedObject = new LazyGameObject<GameObject>(goID).Value(g);
            g.GameObjects.Remove(removedObject);

            if(removedObject is Card)
            {
                removedFrom = g.GetZoneOf((Card)removedObject);
                removedIndex = removedFrom.Contents.FindIndex(x => { return x.ID == removedObject.ID; });
                removedFrom.Contents.RemoveAll(x => { return x.ID == removedObject.ID; });
            }
        }

        private GameObject removedObject;
        private Zone removedFrom;
        private Int32 removedIndex;

        public override void Undo(Game g)
        {
            g.GameObjects.Add(removedObject);
            if(removedFrom != null) 
            {
                removedFrom.Contents.Insert(removedIndex,new LazyGameObject<Card>((Card)removedObject)); 
            }
        }

        public override object Clone()
        {
            return new CommandRemoveGameObjectFromGame(goID);
        }
    }
}
