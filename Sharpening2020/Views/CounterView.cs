using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Views
{
    public class CounterView : ViewObject
    {
        public readonly CounterType Type;

        public CounterView(CounterType ct)
        {
            Type = ct;
        }
    }
}
