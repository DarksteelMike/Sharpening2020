using System;
using System.Collections.Generic;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Cards.ContinuousEffects;
using Sharpening2020.Cards.ContinuousEffects.Presets;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts.Presets;
using Sharpening2020.Commands;
using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Cards
{
    class Selfless_Cathar : Card
    {
        

        

        public override void Build()
        {
            Card.AddUniversalCharacteristics(this);
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Selfless Cathar";
            Front.CardTypes.Add("Creature");
            Front.SubTypes.Add("Human");

            Front.Power = 1;
            Front.Toughness = 1;

            LazyGameObject<Card> lazy = new LazyGameObject<Card>(this);

            CastPermanent cast = new CastPermanent(lazy);

            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.White));

            Front.Activatables.Add(cast);

            PumpAllControlledByControllerUntilEOT paue = new PumpAllControlledByControllerUntilEOT(this);

            paue.MyCost.ActionParts.Add(new SacSelf(new LazyGameObject<Card>(this)));
            paue.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.Colorless));
            paue.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.White));

            Front.Activatables.Add(paue);
        }

        public override object Clone()
        {
            return base.Clone(new Selfless_Cathar());
        }
    }
}
