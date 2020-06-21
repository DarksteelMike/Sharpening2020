using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Cards.Targets
{
    public class Targeting
    {
        public readonly List<GameObject> Targeted = new List<GameObject>();

        public Func<Game, GameObject, Boolean> TargetPredicate = null;

        public Int32 MinTargets = 0;
        public Int32 MaxTargets = 0;

        public Boolean IsFinished()
        {
            return Targeted.Count >= MinTargets && Targeted.Count <= MaxTargets;
        }

        public Boolean CanTargetGameObject(Game g, GameObject go)
        {
            if (TargetPredicate != null)
                return TargetPredicate(g, go);

            return false;
        }
    }
}
