using System;

using Sharpening2020.Zones;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class PredicatePresets
    {
        public static Func<Game, GameObject, Boolean> AnyCreature = (g, x) => {
            if (!(x is Card))
                return false;

            Card c = (Card)x;

            if (g.GetZoneTypeOf(c) != ZoneType.Battlefield)
                return false;

            if (!c.CurrentCharacteristics.CardTypes.Contains("Creature"))
                return false;

            return true;
        };
    }
}
