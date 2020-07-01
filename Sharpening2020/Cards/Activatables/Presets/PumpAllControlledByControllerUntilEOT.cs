using System;

using Sharpening2020.Commands;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class PumpAllControlledByControllerUntilEOT : Ability
    {
        public PumpAllControlledByControllerUntilEOT(Card h)
        {
            Host = new LazyGameObject<Card>(h);
        }

        public PumpAllControlledByControllerUntilEOT(PumpAllControlledByControllerUntilEOT other)
        {
            Host = other.Host;
        }

        public override bool CanActivate(Player act, Game g)
        {
            Boolean res = true;

            res &= !IsBeingActivated;
            res &= act.ID == Host.Value(g).Controller.ID;
            res &= g.GetZoneTypeOf(Host) == ZoneType.Battlefield;

            res &= base.CanActivate(act, g);

            return res;
        }

        public override void Resolve(Game g, StackInstance si)
        {
            g.MyExecutor.Do(new CommandCreatePumpAllControlledByControllerEffect(Host.ID));
        }

        public override string ToString(Game g)
        {
            return "";
        }

        public override object Clone()
        {
            return new PumpAllControlledByControllerUntilEOT(this);
        }
    }
}
