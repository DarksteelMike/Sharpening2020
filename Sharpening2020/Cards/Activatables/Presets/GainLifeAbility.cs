using System;
using System.Collections.Generic;

using Sharpening2020.Commands;
using Sharpening2020.Players;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class GainLifeDefinedAbility : Ability
    {
        private readonly Int32 Amount;
        private readonly LazyGameObject<Player> DefinedPlayer;

        public GainLifeDefinedAbility(LazyGameObject<Card> h, LazyGameObject<Player> p, Int32 a)
        {
            Host = h;
            DefinedPlayer = p;
            Amount = a;
        }

        public override bool CanActivate(Player act, Game g)
        {
            return base.CanActivate(act, g);
        }

        public override void Resolve(Game g, StackInstance si)
        {
            g.MyExecutor.Do(new CommandGainLife(DefinedPlayer.ID, Amount));
        }

        public override object Clone()
        {
            return new GainLifeDefinedAbility(Host, DefinedPlayer, Amount);
        }

        public override string ToString(Game g)
        {
            return DefinedPlayer.Value(g).ToString() + " gains " + Amount.ToString() + " life.";
        }
    }
}
