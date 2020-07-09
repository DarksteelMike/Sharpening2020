using Sharpening2020.Commands;

namespace Sharpening2020.Cards.Costs.ActionCosts.Presets
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
            g.MyExecutor.Do(new CommandSetIsTapped(Target.ID, false));
        }

        public override object Clone()
        {
            TapSelf ret = new TapSelf(Target);

            return ret;
        }

        public override string ToString(Game g)
        {
            return "{U}";
        }
    }
}
