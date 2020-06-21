using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Mana;

namespace Cards.Cards
{
    class Giant_Growth : Card
    {
        public override void Build()
        {
            Card.AddUniversalCharacteristics(this);
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Giant Growth";
            Front.CardTypes.Add("Instant");

            Func<Game,GameObject, Boolean> targetVal = (g,x) => {
                if (!(x is Card))
                    return false;

                Card c = (Card)x;

                if (g.GetZoneTypeOf(c) != ZoneType.Battlefield)
                    return false;

                if (!c.CurrentCharacteristics.CardTypes.Contains("Creature"))
                    return false;

                return true;
            };

            Activatable cast = new PumpSpell(new LazyGameObject<Card>(this), 3, 3);

            cast.MyTargeting.Description = "Creature";
            cast.MyTargeting.TargetPredicate = targetVal;
            cast.MyTargeting.MinTargets = 1;
            cast.MyTargeting.MaxTargets = 1;

            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.Green));

            Front.Activatables.Add(cast);
        }

        public override object Clone()
        {
            return base.Clone(new Giant_Growth());
        }
    }
}
