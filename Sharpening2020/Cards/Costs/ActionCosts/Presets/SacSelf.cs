using System;

using Sharpening2020.Commands;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.Costs.ActionCosts.Presets
{
    public class SacSelf : ActionCostPart
    {
        private LazyGameObject<Card> Target;

        public SacSelf(LazyGameObject<Card> t)
        {
            Target = t;
        }
        public override bool CanBeDone(Game g)
        {
            return g.GetZoneTypeOf(Target) == ZoneType.Battlefield;
        }

        public override void Pay(Game g)
        {
            g.MyExecutor.Do(new CommandSacrifice(Target.ID));
        }

        public override object Clone()
        {
            return new SacSelf(Target);
        }

        public override string ToString(Game g)
        {
            return "Sacrifice CARDNAME";
        }
    }
}
