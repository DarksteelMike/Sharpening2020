using System;

using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Views
{
    class StackInstanceView : ViewObject
    {
        public readonly String Text;

        public StackInstanceView(StackInstance si)
        {
            Text = si.MyActivatable.ToString();
        }
    }
}
