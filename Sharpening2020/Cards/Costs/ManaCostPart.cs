using System;

using Sharpening2020.Mana;

namespace Sharpening2020.Cards.Costs
{ 
    public class ManaCostPart : ICloneable
    {
        public ManaColor Color;

        public ManaPoint PaidPoint;

        public ManaCostPart(ManaColor col)
        {
            Color = col;
        }

        public void Pay(ManaPoint mp, Game g)
        {
            PaidPoint = mp;
        }

        public object Clone()
        {
            ManaCostPart ret = new ManaCostPart(Color);

            return ret;
        }
    }
}
