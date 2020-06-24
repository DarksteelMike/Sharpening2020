using System;

using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Views
{
    public class StackInstanceView : ViewObject
    {
        public readonly String Text;

        public StackInstanceView(StackInstance si)
        {
            id = si.ID;
            Text = si.MyActivatable.ToString();
        }
    }
}
