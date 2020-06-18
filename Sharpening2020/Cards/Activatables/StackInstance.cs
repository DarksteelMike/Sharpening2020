﻿using System.Collections.Generic;
using System.Linq;
using Sharpening2020.Mana;
using Sharpening2020.Views;

namespace Sharpening2020.Cards.Activatables
{
    public class StackInstance : GameObject
    {
        public readonly Activatable MyActivatable;

        public readonly IReadOnlyList<ManaPoint> ManaPaid;

        public StackInstance(Activatable act)
        {
            MyActivatable = act;
;
            List<ManaPoint> PointsPaid = new List<ManaPoint>();
            PointsPaid.AddRange(act.MyCost.PaidMana.Select(x => {return x.PaidPoint;}));

            ManaPaid = PointsPaid.AsReadOnly();
        }

        //Copy constructor
        public StackInstance(StackInstance other)
        {
            this.MyActivatable = other.MyActivatable;
            this.ManaPaid = other.ManaPaid;
        }

        public void Resolve(Game g)
        {
            MyActivatable.Resolve(g, this);
        }

        public override object Clone()
        {
            return new StackInstance(this);
        }

        public override ViewObject GetView()
        {
            return new StackInstanceView(this);
        }

    }
}