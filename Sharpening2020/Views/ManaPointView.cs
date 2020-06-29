using System;

using Sharpening2020.Mana;

namespace Sharpening2020.Views
{
    public class ManaPointView : ViewObject
    {
        public readonly ManaColor Color;

        public ManaPointView(Int32 i, ManaColor c)
        {
            id = i;
            Color = c;
        }

        public override string ToString()
        {
            return Color.ToString();
        }
    }
}
