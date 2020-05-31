using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020
{
    public abstract class GameObject : ICloneable,IEquatable<GameObject>
    {
        public Int32 ID = 0;

        public Game MyGame;

        public Boolean Equals(GameObject other)
        {
            if (other == null)
                return false;

            return this.ID == other.ID;
        }

        public abstract object Clone();
    }
}
