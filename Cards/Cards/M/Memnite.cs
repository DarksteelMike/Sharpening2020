using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables.Presets;

namespace Cards
{
    class Memnite : Card
    {
        public override void Build()
        {
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Memnite";
            Front.CardTypes.Add("Artifact");
            Front.CardTypes.Add("Creature");
            Front.SubTypes.Add("Construct");
            Front.Power = 1;
            Front.Toughness = 1;

            CastPermanent cp = new CastPermanent(new LazyGameObject<Card>(this));
            Front.Activatables.Add(cp);
        }

        public override object Clone()
        {
            return base.Clone(new Memnite());
        }
    }
}
