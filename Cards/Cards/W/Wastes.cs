﻿using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Mana;

namespace Cards
{    
    public class Wastes : Card
    {
        public override void Build()
        {
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Wastes";
            Front.SuperTypes.Add("Basic");
            Front.CardTypes.Add("Land");

            PlayLand pl = new PlayLand(new LazyGameObject<Card>(this));
            Front.Activatables.Add(pl);

            TapForMana tfm = new TapForMana(new LazyGameObject<Card>(this), ManaColor.Colorless);
            tfm.IsManaAbility = true;
            Front.Activatables.Add(tfm);
        }

        public override object Clone()
        {
            return base.Clone(new Wastes());
        }
    }
}
