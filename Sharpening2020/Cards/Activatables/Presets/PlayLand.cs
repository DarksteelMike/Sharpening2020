﻿using System;

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

        public override Boolean CanActivate(Player p, Game g)
        {
            Boolean res = true;

            res &= Host.Value(g).MyZone == ZoneType.Hand; //Only play from hand.
            res &= p.Equals(Host.Value(g).Owner); //Only it's owner can play it.
            res &= p.LandsPlayedThisTurn < 1; //Only play if no other lands have been played this turn.
            res &= !IsBeingActivated; //This isn't already in the process of being cast.

            return res;
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
