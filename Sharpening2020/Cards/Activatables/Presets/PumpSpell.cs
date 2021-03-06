﻿using System;
using System.Linq;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Commands;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class PumpSpell : Spell, ICloneable
    {
        public PumpSpell() { }

        public PumpSpell(LazyGameObject<Card> c, Int32 p, Int32 t)
        {
            Host = c;
            PowerPump = p;
            ToughnessPump = t;
        }

        public readonly Int32 PowerPump;
        public readonly Int32 ToughnessPump;

        public override Boolean CanActivate(Player p, Game g)
        {
            Boolean res = true;

            res &= g.GetZoneTypeOf(Host) == ZoneType.Hand; //Only cast from hand
            res &= p.ID == Host.Value(g).Owner.ID; //Only it's owner can cast it
            res &= !IsBeingActivated; //This isn't already in the process of being cast.
            res &= base.CanActivate(p, g);

            return res;
        }

        public override void Resolve(Game g, StackInstance si)
        {
            foreach(GameObject tgt in si.Targets)
            {
                g.MyExecutor.Do(new CommandCreateStaticPumpEffect(tgt.ID, PowerPump, ToughnessPump));
            }
            
        }

        public override object Clone()
        {
            PumpSpell ret = new PumpSpell();
            ret.MyCost = (Cost)this.MyCost.Clone();

            return ret;
        }

        public override string ToString(Game g)
        {
            return "Cast " + Host.Value(g).CurrentCharacteristics.Name + " for " + Utilities.ColorListToShortenedString(MyCost.ManaParts.Select(x => { return x.Color; }));
        }
    }
}
