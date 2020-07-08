using System;

using ProtoBuf;

namespace Sharpening2020.Input
{
    [ProtoContract]
    public class GameAction : ICloneable
    {
        [ProtoMember(1)]
        public readonly Int32 ID;
        [ProtoMember(2)]
        public readonly Int32 AssociatedGameObjectID;
        [ProtoMember(3)]
        public readonly String Description;

        public GameAction(Int32 id, Int32 goid, String desc)
        {
            ID = id;
            AssociatedGameObjectID = goid;
            Description = desc;
        }

        public object Clone()
        {
            return new GameAction(ID, AssociatedGameObjectID, Description);
        }
    }
}
