using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Mana;
using Sharpening2020.Players;

namespace Sharpening2020.Views
{
    public class PlayerView : ViewObject
    {
        public readonly Int32 Life;
        public readonly IReadOnlyList<CounterView> Counters;
        public readonly IReadOnlyList<ManaPointView> ManaPool;

        public PlayerView(Game g, Player p)
        {
            id = p.ID;
            Life = p.Life;

            List<CounterView> counts = new List<CounterView>();

            foreach(LazyGameObject<Counter> c in p.MyCounters)
            {
                counts.Add((CounterView)c.Value(g).GetView(g, p));
            }

            List<ManaPointView> manas = new List<ManaPointView>();

            foreach(LazyGameObject<ManaPoint> m in p.ManaPool)
            {
                manas.Add((ManaPointView)m.Value(g).GetView(g, p));
            }

            ManaPool = manas.AsReadOnly();
            Counters = counts.AsReadOnly();
        }
    }
}
