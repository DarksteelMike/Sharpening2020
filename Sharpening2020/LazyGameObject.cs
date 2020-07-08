using System;

using ProtoBuf;

namespace Sharpening2020
{
    [ProtoContract]
    public class LazyGameObject<T> : IEquatable<LazyGameObject<T>>, ICloneable where T : GameObject
    {
        [ProtoMember(1)]
        public readonly Int32 ID;
        public LazyGameObject(T go)
        {
            ID = go.ID;
        }

        public LazyGameObject(Int32 goID)
        {
            ID = goID;
        }

        public T Value(Game g) {
            return (T)g.GetGameObjectByID(ID);
        }

        public object Clone()
        {
            return new LazyGameObject<T>(ID);
        }

        public Boolean Equals(LazyGameObject<T> other)
        {
            return ID.Equals(other.ID);
        }
    }
}
