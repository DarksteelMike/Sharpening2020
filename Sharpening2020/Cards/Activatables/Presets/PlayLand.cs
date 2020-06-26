using System;

using Sharpening2020.Commands;
using Sharpening2020.Phases;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class PlayLand : SpecialAction,ICloneable
    {
        public PlayLand() { }
        
        public PlayLand(LazyGameObject<Card> c)
        {
            Host = c;
        }

        public override Boolean CanActivate(Player p, Game g)
        {
            Boolean res = true;

            res &= g.GetZoneTypeOf(Host) == ZoneType.Hand; //Only play from hand.
            res &= p.ID == Host.Value(g).Owner.ID; //Only it's owner can play it.
            res &= p.LandsPlayedThisTurn < 1; //Only play if no other lands have been played this turn.
            res &= g.SpellStack.Count == 0; //Only play if stack is empty.
            res &= (g.MyPhaseHandler.CurrentPhase is PhasePreCombatMain || g.MyPhaseHandler.CurrentPhase is PhasePostCombatMain); //Only play on main phases.
            res &= !IsBeingActivated; //This isn't already in the process of being cast.

            return res;
        }

        public override void Resolve(Game g, StackInstance si)
        {
            g.MyExecutor.Do(new CommandMoveCard(Host.ID, ZoneType.Battlefield));
            g.MyExecutor.Do(new CommandIncrementLandsPlayed(Activator.ID));
        }

        public override object Clone()
        {
            PlayLand ret = new PlayLand();

            return ret;
        }

        public override string ToString(Game g)
        {
            return "Play " + Host.Value(g).CurrentCharacteristics.Name;
        }
    }
}
