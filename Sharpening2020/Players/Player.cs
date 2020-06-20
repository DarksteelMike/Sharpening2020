using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Mana;
using Sharpening2020.Phases;
using Sharpening2020.Views;

namespace Sharpening2020.Players
{
    public class Player : GameObject, ICanHaveCounters, ICloneable
    {
        public Player() { }

        public static Player Construct()
        {
            Player ret = new Player();
            ret.Life = 20;

            return ret;
        }

        public Int32 Life;

        public Int32 LandsPlayedThisTurn = 0;

        public List<LazyGameObject<Counter>> MyCounters = new List<LazyGameObject<Counter>>();

        public List<ManaPoint> ManaPool = new List<ManaPoint>();

        public PhaseHandler MyPhases = new PhaseHandler();

        public Int32 GetCounterAmount(Game g, CounterType ct)
        {
            return MyCounters.Where(x => { return x.Value(g).MyType == ct; }).Count();
        }

        public void RemoveCounter(Counter c)
        {
            MyCounters.RemoveAll(x => { return x.ID == c.ID; });
        }

        public void AddCounter(Counter c)
        {
            MyCounters.Add(new LazyGameObject<Counter>(c));
        }

        public IEnumerable<Counter> GetAllCounters(Game g)
        {
            return MyCounters.Select(x => { return x.Value(g); });
        }

        public override object Clone() {
            Player ret = new Player();
            ret.ID = this.ID;
            ret.Life = this.Life;

            return ret;
        }

        public override ViewObject GetView(Game g)
        {
            return new PlayerView(g, ID, Life, MyCounters.Select(x => { return x.Value(g); }).ToList() , ManaPool);
        }
    }
}
