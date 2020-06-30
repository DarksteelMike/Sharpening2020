using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Mana;

namespace Cards
{
    class Grizzly_Bears : Card
    {
        public override void Build()
        {
            Card.AddUniversalCharacteristics(this);
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Grizzly Bears";
            Front.CardTypes.Add("Creature");
            Front.SubTypes.Add("Bear");
            Front.Power = 2;
            Front.Toughness = 2;

            Activatable cast = new CastPermanent(new LazyGameObject<Card>(this));

            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.Colorless));
            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.Green));

            Front.Activatables.Add(cast);
        }

        public override object Clone()
        {
            return base.Clone(new Grizzly_Bears());
        }
    }
}
