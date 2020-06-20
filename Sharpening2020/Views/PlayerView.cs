using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Mana;

namespace Sharpening2020.Views
{
    public class PlayerView : ViewObject
    {
        public readonly Int32 ID;
        public readonly Int32 Life;
        public readonly IReadOnlyList<CounterView> Counters;
        public readonly IReadOnlyList<ManaPointView> ManaPool;

        public PlayerView(Game g, Int32 i, Int32 l, List<Counter> cts, List<ManaPoint> mp)
        {
            ID = i;
            Life = l;

            List<CounterView> counts = new List<CounterView>();

            foreach(Counter c in cts)
            {
                counts.Add((CounterView)c.GetView(g));
            }

            List<ManaPointView> manas = new List<ManaPointView>();

            foreach(ManaPoint m in mp)
            {
                manas.Add((ManaPointView)m.GetView(g));
            }

            ManaPool = manas.AsReadOnly();
            Counters = counts.AsReadOnly();
        }
    }
}
