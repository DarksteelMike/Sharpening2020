using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables.Presets;

namespace Cards
{
    class Memnite : Card
    {
        public Memnite()
        {
            Card.AddUniversalCharacteristics(this);
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
    }
}
