using System;

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

        public override bool CanActivate(Player act, Game g)
        {
            return act.Equals(Host.Value(g).Controller.Value(g)) && Host.Value(g).MyZone == ZoneType.Battlefield;
        }

        public override void Resolve(Game g)
        {
            CommandBase com = new CommandAddManaToPool(Activator.ID, Color);
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
