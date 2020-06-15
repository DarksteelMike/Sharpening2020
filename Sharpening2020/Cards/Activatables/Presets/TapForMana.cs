﻿using System;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Commands;
using Sharpening2020.Mana;
using Sharpening2020.Players;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class TapForMana : Ability,ICloneable
    {
        public ManaColor Color;

        public TapForMana(LazyGameObject<Card> h, ManaColor color)
        {
            Host = h;
            Color = color;
            IsManaAbility = true;

            MyCost.ActionParts.Add(new TapSelf(Host));
        }

        public override Boolean CanActivate(Player p, Game g)
        {
            Boolean res = true;

            res &= Host.Value(g).MyZone == ZoneType.Battlefield; //Only activate on the battlefield
            res &= p.Equals(Host.Value(g).Controller); //Only it's controller can activate it
            res &= !IsBeingActivated; //This isn't already in the process of being activated.

            return res;
        }

        public override void Resolve(Game g, StackInstance si)
        {
            g.MyExecutor.Do(new CommandAddManaToPool(Activator.ID, Color));
        }

        public override object Clone()
        {
            TapForMana ret = new TapForMana(Host, Color);
            ret.MyCost = (Cost)this.MyCost.Clone();

            return ret;
        }

        public override string ToString(Game g)
        {
            return "Tap " + Host.Value(g).CurrentCharacteristics.Name + " for " + Color.ToString() + " mana";
        }
    }
}
