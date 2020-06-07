using System;
using System.Collections.Generic;

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

        public CardView(Card crd)
        {
            ID = crd.ID;
            Name = crd.CurrentCharacteristics.Name;
            SuperTypes = crd.CurrentCharacteristics.SuperTypes.AsReadOnly();
            CardTypes = crd.CurrentCharacteristics.CardTypes.AsReadOnly();
            SubTypes = crd.CurrentCharacteristics.SubTypes.AsReadOnly();

            String txt = "";

            foreach (Activatable act in crd.CurrentCharacteristics.Activatables)
            {
                txt += act.ToString() + Environment.NewLine;
            }

            Text = txt;

            Power = crd.CurrentCharacteristics.Power;
            Toughness = crd.CurrentCharacteristics.Toughness;
            AssignedDamage = crd.AssignedDamage;

            List<CounterView> cts = new List<CounterView>();

            foreach(Counter c in crd.MyCounters)
            {
                cts.Add((CounterView)c.GetView());
            }

            Counters = cts.AsReadOnly();
        }
    }
}
