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
        
        public LazyGameObject<Player> Owner;
        public LazyGameObject<Player> Controller;

        public List<LazyGameObject<Counter>> MyCounters = new List<LazyGameObject<Counter>>();

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

        public override ViewObject GetView(Game g)
        {
            return new CardView(g, this);
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

            foreach(LazyGameObject<Counter> c in MyCounters)
            {
                ret.MyCounters.Add((LazyGameObject<Counter>)c.Clone());
            }

            ret.CurrentCharacteristicName = this.CurrentCharacteristicName;
            ret.IsTapped = this.IsTapped;
            ret.IsToken = this.IsToken;

            return ret;
        }
    }
}
