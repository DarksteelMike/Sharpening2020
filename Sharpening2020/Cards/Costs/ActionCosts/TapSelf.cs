using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Cards.Costs.ActionCosts
{
    public class TapSelf : ActionCostPart
    {
        private LazyGameObject<Card> Target;

        public TapSelf(LazyGameObject<Card> c)
        {
            Target = c;
        }

        public override bool CanBeDone(Game g)
        {
            return !Target.Value(g).IsTapped;
        }

        public override void Pay(Game g)
        {
            Commands.CommandTap ct = new Commands.CommandTap(Target.ID);

            g.MyExecutor.Do(ct);
        }

        public override object Clone()
        {
            TapSelf ret = new TapSelf(Target);

            return ret;
        }
    }
}
