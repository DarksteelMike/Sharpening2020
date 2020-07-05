using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharpening2020.Players;
using Sharpening2020.Views;

namespace Sharpening2020
{
    public abstract class GameObject : ICloneable,IEquatable<GameObject>
    {
        private Int32 id = 0;
        public Int32 ID
        {
            get { return id; }
            set { id = value; }
        }

        public Game MyGame;

        public Boolean Equals(GameObject other)
        {
            if (other == null)
                return false;

            return this.ID == other.ID;
        }

        public abstract String ToString(Game g);

        public abstract ViewObject GetView(Game g, Player viewer);

        public abstract object Clone();
    }
}
