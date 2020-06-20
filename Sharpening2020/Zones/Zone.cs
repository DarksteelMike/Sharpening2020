using System;
using System.Collections.Generic;

using Sharpening2020.Cards;

namespace Sharpening2020.Zones
{
    public class Zone : ICloneable
    {
        public readonly ZoneType MyType;
        public readonly List<LazyGameObject<Card>> Contents;

        public readonly List<LazyGameObject<Card>> EnteredThisTurn;

        public Zone(ZoneType zt)
        {
            MyType = zt;
            Contents = new List<LazyGameObject<Card>>();
            EnteredThisTurn = new List<LazyGameObject<Card>>();
        }

        public void Shuffle(Int32 Seed)
        {
            
        }

        public object Clone()
        {
            Zone ret = new Zone(MyType);

            foreach(LazyGameObject<Card> lc in Contents)
            {
                ret.Contents.Add(lc);
            }

            foreach (LazyGameObject<Card> lc in EnteredThisTurn)
            {
                ret.EnteredThisTurn.Add(lc);
            }

            return ret;
        }
    }
}
