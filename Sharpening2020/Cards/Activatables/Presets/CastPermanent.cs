using System;
using System.Linq;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Commands;
using Sharpening2020.Phases;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class CastPermanent : Spell,ICloneable
    {
        public CastPermanent() { }
        public CastPermanent(LazyGameObject<Card> h)
        {
            Host = h;
        }

        public override Boolean CanActivate(Player p, Game g)
        {
            Boolean res = true;

            res &= g.GetZoneTypeOf(Host) == ZoneType.Hand; //Only cast from hand.
            res &= p.ID == Host.Value(g).Owner.ID; //Only it's owner can cast it.
            res &= g.MyPhaseHandler.CurrentPhase.MyType == PhaseType.PostCombatMain || g.MyPhaseHandler.CurrentPhase.MyType == PhaseType.PreCombatMain; //Only cast on main phases
            res &= p.ID == g.ActivePlayer.ID; //Only cast on your turn.
            res &= g.SpellStack.Count == 0; //Only cast at sorcery speed.
            res &= !IsBeingActivated; //This isn't already in the process of being cast.

            return res;
        }

        public override void Resolve(Game g, StackInstance si)
        {
            g.MyExecutor.Do(new CommandMoveCard(Host.ID, ZoneType.Battlefield));
        }

        public override object Clone()
        {
            CastPermanent ret = new CastPermanent();
            ret.MyCost = (Cost)this.MyCost.Clone();

            return ret;
        }

        public override string ToString(Game g)
        {
            return "Cast " + Host.Value(g).CurrentCharacteristics.Name + " for " + Utilities.ColorListToShortenedString(MyCost.ManaParts.Select(x => { return x.Color; }));
        }
    }
}
