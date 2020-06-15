﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpening2020.Views;

namespace Sharpening2020.Cards.Activatables
{
    public class StackInstance : GameObject
    {
        public readonly Activatable MyActivatable;

        public StackInstance(Activatable act)
        {
            MyActivatable = act;
        }

        public void Resolve(Game g)
        {
            MyActivatable.Resolve(g, this);
        }

        public override object Clone()
        {
            return new StackInstance(MyActivatable);
        }

        public override ViewObject GetView()
        {
            return new StackInstanceView(this);
        }

    }
}
