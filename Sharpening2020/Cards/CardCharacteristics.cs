using Sharpening2020.Cards.ContinuousEffects;
using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Cards
{
    public enum CharacteristicName { Front, Back, FaceDown, Morph, Manifest, Flip, Cloned, Alternate }
    public class CardCharacteristics : ICloneable
    {
        public String Name;
        public List<String> CardTypes = new List<String>();
        public List<String> SubTypes = new List<String>();
        public List<String> SuperTypes = new List<String>();
        public Int32 Power;
        public Int32 Toughness;

        public List<Activatable> Activatables = new List<Activatable>();

        public List<ContinuousEffect> ContinuousEffects = new List<ContinuousEffect>();

        public object Clone()
        {
            CardCharacteristics ret = new CardCharacteristics();

            ret.Name = this.Name;
            foreach(String s in this.CardTypes)
            {
                ret.CardTypes.Add(s);
            }
            foreach (String s in this.SubTypes)
            {
                ret.SubTypes.Add(s);
            }
            foreach (String s in this.SuperTypes)
            {
                ret.SuperTypes.Add(s);
            }

            ret.Power = this.Power;
            ret.Toughness = this.Toughness;

            foreach(Activatable act in Activatables)
            {
                ret.Activatables.Add((Activatable)act.Clone());
            }

            foreach(ContinuousEffect ce in ContinuousEffects)
            {
                ret.ContinuousEffects.Add((ContinuousEffect)ce.Clone());
            }

            return ret;
        }
    }
}
