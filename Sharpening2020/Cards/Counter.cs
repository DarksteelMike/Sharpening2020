using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpening2020.Views;

namespace Sharpening2020.Cards
{
    public enum CounterType { P1P1, M1M1, Loyalty }
    public class Counter : GameObject
    {
        public CounterType MyType;

        public Counter(CounterType ct)
        {
            MyType = ct;
        }

        public override object Clone()
        {
            Counter ret = new Counter(MyType);

            return ret;
        }

        public override ViewObject GetView(Game g)
        {
            return new CounterView(MyType);
        }
    }
}
