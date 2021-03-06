﻿using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Players;
using Sharpening2020.Views;

namespace Sharpening2020.Cards
{
    public abstract class Card : GameObject, ICanHaveCounters, ICanBeAttacked, ICloneable
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
        
        private readonly Stack<LazyGameObject<Player>> controllerStack = new Stack<LazyGameObject<Player>>();

        public LazyGameObject<Player> Owner;
        public LazyGameObject<Player> Controller
        {
            get
            {
                if (controllerStack.Count > 0)
                    return controllerStack.Peek();

                return Owner;
            }

            set
            {
                controllerStack.Push(value);
            }
        }

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

        public override ViewObject GetView(Game g, Player viewer)
        {
            return new CardView(g, this, viewer, CurrentCharacteristicName);
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

            FaceDown.Name = "Face down card";

            c.MyCharacteristics.Add(CharacteristicName.Front, Front);
            c.MyCharacteristics.Add(CharacteristicName.Back, Back);
            c.MyCharacteristics.Add(CharacteristicName.FaceDown, FaceDown);
            c.MyCharacteristics.Add(CharacteristicName.Morph, Morph);
            c.MyCharacteristics.Add(CharacteristicName.Manifest, Manifest);
        }

        public abstract void Build();

        protected object Clone(Card ret)
        {
            ret.ID = this.ID;

            foreach (CharacteristicName cn in MyCharacteristics.Keys)
            {
                ret.MyCharacteristics.Add(cn, (CardCharacteristics)this.MyCharacteristics[cn].Clone());
            }

            foreach (LazyGameObject<Counter> c in MyCounters)
            {
                ret.MyCounters.Add((LazyGameObject<Counter>)c.Clone());
            }

            ret.CurrentCharacteristicName = this.CurrentCharacteristicName;
            ret.IsTapped = this.IsTapped;
            ret.IsToken = this.IsToken;

            return ret;
        }

        public override string ToString(Game g)
        {
            return CurrentCharacteristics.Name + "(" + ID + ")";
        }
    }
}
