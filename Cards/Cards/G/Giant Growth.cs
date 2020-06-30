using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Mana;
using Sharpening2020.Zones;

namespace Cards
{
    class Giant_Growth : Card
    {
        public override void Build()
        {
            Card.AddUniversalCharacteristics(this);
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Giant Growth";
            Front.CardTypes.Add("Instant");

            

            Activatable cast = new PumpSpell(new LazyGameObject<Card>(this), 3, 3);

            cast.MyTargeting.Description = "Creature";
            cast.MyTargeting.TargetPredicate = PredicatePresets.AnyCreature;
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
