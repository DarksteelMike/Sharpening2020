﻿using System;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Players;

namespace Sharpening2020.Cards.Activatables
{
    public abstract class Activatable : ICloneable
    {
        public LazyGameObject<Card> Host;

        public Player Activator;

        public Cost MyCost = new Cost();

        public abstract Boolean CanActivate(Player act, Game g);
        public abstract void Resolve(Game g);

        public abstract object Clone();

        public abstract String ToString(Game g);
    }
}
