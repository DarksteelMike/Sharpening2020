using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Cards
{
    public enum CounterType { P1P1, M1M1, Loyalty }
    public class Counter : ICloneable
    {
        public CounterType MyType;

        public object Clone()
        {
            Counter ret = new Counter();
            ret.MyType = this.MyType;

            return ret;
        }
    }
}
