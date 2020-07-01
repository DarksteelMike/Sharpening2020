﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020
{
    public class LazyGameObject<T> : IEquatable<LazyGameObject<T>> where T : GameObject, ICloneable
    {
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
