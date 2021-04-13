using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Mana;

namespace Cards
{
    class Llanowar_Elves : Card
    {
        public override void Build()
        {
            CardCharacteristics front = MyCharacteristics[CharacteristicName.Front];

            front.Name = "Llanowar Elves";
            front.CardTypes.Add("Creature");
            front.SubTypes.Add("Elf");
            front.Power = 1;
            front.Toughness = 1;

            LazyGameObject<Card> lazy = new LazyGameObject<Card>(this);

            CastPermanent cast = new CastPermanent(lazy);
            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.Green));

            front.Activatables.Add(cast);

            TapForMana tfm = new TapForMana(lazy, ManaColor.Green);

            front.Activatables.Add(tfm);
        }

        public override object Clone()
        {
            return base.Clone(new Llanowar_Elves());
        }
    }
}
