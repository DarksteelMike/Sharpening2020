using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpening2020.Views;

namespace Sharpening2020.Mana
{
    public enum ManaColor { White, Blue, Black, Red, Green, Colorless };
    public class ManaPoint : GameObject, ICloneable
    {
        public ManaColor MyColor;

        public override object Clone()
        {
            ManaPoint ret = new ManaPoint();
            ret.ID = this.ID;
            ret.MyColor = this.MyColor;

            return ret;
        }

        public override ViewObject GetView(Game g)
        {
            return new ManaPointView(ID,MyColor);
        }
    }
}
