using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Views
{
    public class CardView : ViewObject
    {
        public readonly Int32 ID;

        public readonly String Name;

        public readonly IReadOnlyList<String> SuperTypes;

        public readonly IReadOnlyList<String> CardTypes;

        public readonly IReadOnlyList<String> SubTypes;

        public readonly String Text;

        public readonly Int32 Power;

        public readonly Int32 Toughness;

        public readonly Int32 AssignedDamage;

        public readonly IReadOnlyList<CounterView> Counters;

        public readonly CardView AlternateView;

        public CardView(Card crd) : this(crd, crd.CurrentCharacteristicName, null)
        {
            
        }

        public CardView(Card crd, CharacteristicName cn, CardView ForceAltView)
        {
            ID = crd.ID;
            CardCharacteristics chara = crd.MyCharacteristics[cn];
            Name = chara.Name;
            SuperTypes = chara.SuperTypes.AsReadOnly();
            CardTypes = chara.CardTypes.AsReadOnly();
            SubTypes = chara.SubTypes.AsReadOnly();

            String txt = "";

            foreach (Activatable act in chara.Activatables)
            {
                txt += act.ToString() + Environment.NewLine;
            }

            Text = txt;

            Power = chara.Power;
            Toughness = chara.Toughness;
            AssignedDamage = crd.AssignedDamage;

            Counters = crd.MyCounters.Select(x => { return (CounterView)x.GetView(); }).ToList().AsReadOnly();

            if (ForceAltView != null)
            {
                AlternateView = ForceAltView;
            }
            else
            {
                if(cn == CharacteristicName.Flip || 
                   cn == CharacteristicName.FaceDown || 
                   cn == CharacteristicName.Back ||
                   cn == CharacteristicName.Manifest ||
                   cn == CharacteristicName.Morph)
                {
                    AlternateView = new CardView(crd, CharacteristicName.Front, this);
                }

                if(cn == CharacteristicName.Front)
                {
                    if(crd.MyCharacteristics.ContainsKey(CharacteristicName.Flip))
                    {
                        AlternateView = new CardView(crd, CharacteristicName.Flip, this);
                    }
                    else if (crd.MyCharacteristics.ContainsKey(CharacteristicName.Back))
                    {
                        AlternateView = new CardView(crd, CharacteristicName.Back, this);
                    }
                    else
                    {
                        AlternateView = null;
                    }
                }
            }

            
        }
    }
}
