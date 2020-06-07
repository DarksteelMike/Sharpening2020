using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Static;
using Sharpening2020.Players;
using Sharpening2020.Views;

namespace Sharpening2020.Cards
{
    public enum ZoneType { Command, Library, Hand, Stack, Battlefield, Graveyard, Exile }
    public class Card : GameObject,ICanHaveCounters, ICloneable
    {
        public CharacteristicName CurrentCharacteristicName = CharacteristicName.Front;
        public Dictionary<CharacteristicName, CardCharacteristics> MyCharacteristics = new Dictionary<CharacteristicName, CardCharacteristics>();
        public CardCharacteristics CurrentCharacteristics
        {
            get { return MyCharacteristics[CurrentCharacteristicName]; }
        }

        public Boolean IsTapped = false;
        public Boolean IsToken = false;
        public Boolean HasSummoningSickness = false;
        public Int32 AssignedDamage = 0;

        public ZoneType MyZone = ZoneType.Library;

        public LazyGameObject<Player> Owner;
        public LazyGameObject<Player> Controller;

        public List<Counter> MyCounters = new List<Counter>();

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

        public void RemoveCounterType(CounterType c)
        {
            IEnumerable<Counter> cts = MyCounters.Where(x => { return x.MyType == c; });
            if (cts.Count() == 0)
                return;
            MyCounters.Remove(cts.First());
        }

        public IEnumerable<Counter> GetAllCounters()
        {
            return MyCounters;
        }

        public override ViewObject GetView()
        {
            return new CardView(this);
        }

        public static void AddUniversalCharacteristics(Card c)
        {
            CardCharacteristics Front, Back, FaceDown, Morph, Manifest;
            Front = new CardCharacteristics();
            Back = new CardCharacteristics();
            FaceDown = new CardCharacteristics();
            Morph = new CardCharacteristics();
            Manifest = new CardCharacteristics();

            Morph.CardTypes.Add("Creature");
            Morph.Power = 2;
            Morph.Toughness = 2;

            Manifest.CardTypes.Add("Creature");
            Manifest.Power = 2;
            Manifest.Toughness = 2;

            c.MyCharacteristics.Add(CharacteristicName.Front, Front);
            c.MyCharacteristics.Add(CharacteristicName.Back, Back);
            c.MyCharacteristics.Add(CharacteristicName.FaceDown, FaceDown);
            c.MyCharacteristics.Add(CharacteristicName.Morph, Morph);
            c.MyCharacteristics.Add(CharacteristicName.Manifest, Manifest);
        }

        public override object Clone()
        {
            Card ret = new Card();

            ret.ID = this.ID;

            foreach(CharacteristicName cn in MyCharacteristics.Keys)
            {
                ret.MyCharacteristics.Add(cn,(CardCharacteristics)this.MyCharacteristics[cn].Clone());
            }

            foreach(Counter c in MyCounters)
            {
                ret.MyCounters.Add((Counter)c.Clone());
            }

            ret.CurrentCharacteristicName = this.CurrentCharacteristicName;
            ret.IsTapped = this.IsTapped;
            ret.IsToken = this.IsToken;

            return ret;
        }
    }
}
