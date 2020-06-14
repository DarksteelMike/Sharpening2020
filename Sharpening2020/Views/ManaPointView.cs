using System;

using Sharpening2020.Mana;

namespace Sharpening2020.Views
{
    public class ManaPointView : ViewObject
    {
        public readonly Int32 ID;
        public readonly ManaColor Color;

        public ManaPointView(Int32 i, ManaColor c)
        {
            ID = i;
            Color = c;
        }
    }
}
