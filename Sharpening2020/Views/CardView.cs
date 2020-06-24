using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Views
{
    public class CardView : ViewObject
    {
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

        public CardView(Game g, Card crd, Player v) : this(g, crd, v, crd.CurrentCharacteristicName, null)
        {
            
        }

        public CardView(Game g, Card crd, Player v, CharacteristicName cn, CardView ForceAltView)
        {
            if(g.DebugFlag)
            {
                g.DebugAlert("CardView Constructor:"
                + "\nID: " + crd.ID
                + "\nName: " + crd.MyCharacteristics[CharacteristicName.Front].Name
                + "\nOwner: " + crd.Owner.ID
                + " Viewer: " + v.ID);
            }            

            id = crd.ID;
            CardCharacteristics chara;
            ZoneType zone = g.GetZoneTypeOf(crd);
            chara = crd.MyCharacteristics[cn];
            if ((zone == ZoneType.Hand || zone == ZoneType.Library) && !g.DebugFlag)
            {
                if(v.ID != crd.Owner.ID)
                    chara = crd.MyCharacteristics[CharacteristicName.FaceDown];
            }
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

            Counters = crd.MyCounters.Select(x => { return (CounterView)x.Value(g).GetView(g, v); }).ToList().AsReadOnly();

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
                    AlternateView = new CardView(g, crd, v, CharacteristicName.Front, this);
                }

                if(cn == CharacteristicName.Front)
                {
                    if(crd.MyCharacteristics.ContainsKey(CharacteristicName.Flip))
                    {
                        AlternateView = new CardView(g, crd, v, CharacteristicName.Flip, this);
                    }
                    else if (crd.MyCharacteristics.ContainsKey(CharacteristicName.Back))
                    {
                        AlternateView = new CardView(g, crd, v, CharacteristicName.Back, this);
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
