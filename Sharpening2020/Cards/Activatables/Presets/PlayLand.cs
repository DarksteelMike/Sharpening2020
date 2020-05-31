using System;

using Sharpening2020.Commands;
using Sharpening2020.Players;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class PlayLand : SpecialAction,ICloneable
    {
        public PlayLand() { }
        public PlayLand(LazyGameObject<Card> c)
        {
            Host = c;
        }

        public override bool CanActivate(Player p, Game g)
        {
            if (Host.Value(g).MyZone != ZoneType.Hand)
            {
                return false;
            }

            if (Activator.LandsPlayedThisTurn > 0)
            {
                return false;
            }

            return true;
        }

        public override void Resolve(Game g)
        {
            g.MyExecutor.Do(new CommandMoveCard(Host.Value(g).ID, ZoneType.Hand, ZoneType.Battlefield));
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
