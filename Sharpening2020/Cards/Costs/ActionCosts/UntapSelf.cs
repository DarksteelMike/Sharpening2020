using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharpening2020.Commands;

namespace Sharpening2020.Cards.Costs.ActionCosts
{
    class UntapSelf : ActionCostPart
    {
        private LazyGameObject<Card> Target;

        public UntapSelf(Card c) : this(new LazyGameObject<Card>(c))
        {

        }

        public UntapSelf(LazyGameObject<Card> c)
        {
            Target = c;
        }

        public override bool CanBeDone(Game g)
        {
            return Target.Value(g).IsTapped;
        }

        public override void Pay(Game g)
        {
            g.MyExecutor.Do(new CommandUntap(Target.ID));
        }

        public override object Clone()
        {
            TapSelf ret = new TapSelf(Target);

            return ret;
        }

        public override string ToString(Game g)
        {
            return "Untap " + Target.Value(g);
        }
    }
}
