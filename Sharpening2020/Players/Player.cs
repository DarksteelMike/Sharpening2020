using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Mana;
using Sharpening2020.Phases;

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

        public List<Counter> MyCounters = new List<Counter>();

        public List<ManaPoint> ManaPool = new List<ManaPoint>();

        public PhaseHandler MyPhases = new PhaseHandler();

        public Int32 GetCounterAmount(CounterType ct)
        {
            return MyCounters.Where(x => { return x.MyType == ct; }).Count();
        }

        public void AddCounter(Counter c)
        {
            MyCounters.Add(c);
        }

        public void RemoveCounter(Counter c)
        {
            MyCounters.Remove(c);
        }

        public IEnumerable<Counter> GetAllCounters()
        {
            return MyCounters;
        }

        public void RemoveCounterType(CounterType c)
        {
            IEnumerable<Counter> cts = MyCounters.Where(x => { return x.MyType == c; });
            if (cts.Count() == 0)
                return;
            MyCounters.Remove(cts.First());
        }

        public override object Clone() {
            Player ret = new Player();
            ret.ID = this.ID;
            ret.Life = this.Life;

            return ret;
        }

        
    }
}
