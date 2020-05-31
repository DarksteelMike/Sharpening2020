using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Input
{
    public class GameAction : ICloneable
    {
        public readonly Int32 ID;
        public readonly Int32 AssociatedGameObjectID;
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
