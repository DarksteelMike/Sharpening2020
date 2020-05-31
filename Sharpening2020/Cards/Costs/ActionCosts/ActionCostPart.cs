using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Cards.Costs.ActionCosts
{
    public abstract class ActionCostPart : ICloneable
    {
        public abstract Boolean CanBeDone(Game g);

        public abstract void Pay(Game g);

        public abstract object Clone();
    }
}
