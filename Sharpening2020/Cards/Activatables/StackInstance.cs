using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Views;

namespace Sharpening2020.Cards.Activatables
{
    public class StackInstance : GameObject
    {
        public readonly Activatable MyActivatable;

        public readonly IReadOnlyList<ManaPoint> ManaPaid;

        public readonly IReadOnlyList<GameObject> Targets;

        public StackInstance(Activatable act)
        {
            MyActivatable = act;

            List<ManaPoint> PointsPaid = new List<ManaPoint>();
            PointsPaid.AddRange(act.MyCost.PaidMana.Select(x => {return x.PaidPoint;}));

            ManaPaid = PointsPaid.AsReadOnly();

            List<GameObject> TargetsChosen = new List<GameObject>();
            TargetsChosen.AddRange(act.MyTargeting.Targeted);

            Targets = TargetsChosen.AsReadOnly();
        }

        //Copy constructor
        public StackInstance(StackInstance other)
        {
            this.MyActivatable = other.MyActivatable;
            this.ManaPaid = other.ManaPaid;
            this.Targets = other.Targets;
        }

        public void Resolve(Game g)
        {
            MyActivatable.Resolve(g, this);
        }

        public override object Clone()
        {
            return new StackInstance(this);
        }

        public override string ToString(Game g)
        {
            string res = MyActivatable.ToString(g) + "{Targets: ";
            foreach(GameObject go in Targets)
            {
                res += go.ToString(g) + ",";
            }

            res = res.Substring(0, res.Length - 1) + "}{ManaPaid: ";
            foreach (GameObject go in Targets)
            {
                res += go.ToString(g) + ",";
            }
            res = res.Substring(0, res.Length - 1) + "}";

            return res;
        }

        public override ViewObject GetView(Game g, Player viewer)
        {
            return new StackInstanceView(this);
        }

    }
}
