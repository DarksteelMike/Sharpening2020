using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Mana;
using Sharpening2020.Phases;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020.Players
{
    public class Player : GameObject, ICanHaveCounters, ICloneable
    {
        public Player() { }

        public void Build()
        {
            Life = 20;

            MyZones.Add(ZoneType.Battlefield, new Zone(ZoneType.Battlefield));
            MyZones.Add(ZoneType.Command, new Zone(ZoneType.Command));
            MyZones.Add(ZoneType.Exile, new Zone(ZoneType.Exile));
            MyZones.Add(ZoneType.Graveyard, new Zone(ZoneType.Graveyard));
            MyZones.Add(ZoneType.Hand, new Zone(ZoneType.Hand));
            MyZones.Add(ZoneType.Library, new Zone(ZoneType.Library));
        }

        public Int32 Life;

        public Int32 LandsPlayedThisTurn = 0;

        public Int32 CardsDrawnThisTurn = 0;

        public readonly List<LazyGameObject<Counter>> MyCounters = new List<LazyGameObject<Counter>>();

        public readonly List<LazyGameObject<ManaPoint>> ManaPool = new List<LazyGameObject<ManaPoint>>();

        public readonly PhaseHandler MyPhases = new PhaseHandler();

        public readonly Dictionary<ZoneType, Zone> MyZones = new Dictionary<ZoneType, Zone>();

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

            foreach(ZoneType key in MyZones.Keys)
            {
                ret.MyZones.Add(key, (Zone)MyZones[key].Clone());
            }

            return ret;
        }

        public override ViewObject GetView(Game g)
        {
            return new PlayerView(g, ID, Life, MyCounters.Select(x => { return x.Value(g); }).ToList() , ManaPool.Select(x => { return x.Value(g); }).ToList());
        }
    }
}
