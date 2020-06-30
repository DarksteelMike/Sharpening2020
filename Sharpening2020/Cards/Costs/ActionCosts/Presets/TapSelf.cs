using Sharpening2020.Commands;

namespace Sharpening2020.Cards.Costs.ActionCosts.Presets
{
    public class TapSelf : ActionCostPart
    {
        private LazyGameObject<Card> Target;

        public TapSelf(Card c) : this(new LazyGameObject<Card>(c))
        {

        }

        public TapSelf(LazyGameObject<Card> c)
        {
            Target = c;
        }

        public override bool CanBeDone(Game g)
        {
            if(Target.Value(g).HasSummoningSickness && Target.Value(g).CurrentCharacteristics.CardTypes.Contains("Creature"))
            {
                return false;
            }
            if(Target.Value(g).IsTapped)
            {
                return false;
            }
            return true;
        }

        public override void Pay(Game g)
        {
            Commands.CommandTap ct = new CommandTap(Target.ID);

            g.MyExecutor.Do(ct);
        }

        public override object Clone()
        {
            TapSelf ret = new TapSelf(Target);

            return ret;
        }

        public override string ToString(Game g)
        {
            return "{T}";
        }
    }
}
