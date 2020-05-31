using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Input
{
    public class GameAction
    {
        public readonly Int32 ID;
        public readonly Int32 AssociatedGameObjectID;
        public readonly String description;

        public GameAction(Int32 id, Int32 goid, String desc)
        {
            ID = id;
            AssociatedGameObjectID = goid;
            description = desc;
        }
    }
}
