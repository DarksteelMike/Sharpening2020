using Sharpening2020.Cards.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Triggers;

namespace Sharpening2020.Cards
{
    public enum CharacteristicName { Front, Back, FaceDown, Morph, Manifest, Flip, Cloned, Alternate }
    public enum AbilityType { Activatable, Trigger, Replacement }
    public class CardCharacteristics : ICloneable
    {
        public String Name;
        public List<String> CardTypes = new List<String>();
        public List<String> SubTypes = new List<String>();
        public List<String> SuperTypes = new List<String>();
        public Int32 Power;
        public Int32 Toughness;

        public readonly List<Activatable> Activatables = new List<Activatable>();
        public readonly List<Trigger> Triggers = new List<Trigger>();

        public List<ContinuousEffect> ContinuousEffects = new List<ContinuousEffect>();

        public Int32 IndexOfAbility(Activatable act, AbilityType mode)
        {
            if(mode == AbilityType.Trigger)
            {
                List<Activatable> trigacts = Triggers.Select((x) => { return (Activatable)x.myAbility; }).ToList();
                int res = trigacts.IndexOf(act);
                return res;
            }
            else if( mode == AbilityType.Replacement)
            {
                return 0;
            }
            else
            {
                return Activatables.IndexOf(act);
            }
        }

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
