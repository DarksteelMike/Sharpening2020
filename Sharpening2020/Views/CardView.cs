using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CardView(Int32 i, String n, List<String> st, List<String> ct, List<String> subt, String t, Int32 p, Int32 tough, Int32 ass)
        {
            ID = i;
            Name = n;
            SuperTypes = st.AsReadOnly();
            CardTypes = ct.AsReadOnly();
            SubTypes = subt.AsReadOnly();
            Text = t;
            Power = p;
            Toughness = tough;
            AssignedDamage = ass;
        }
    }
}
