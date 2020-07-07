using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Mana;

namespace Sharpening2020
{
    class Utilities
    {
        public static String ColorToShortenedString(ManaColor col)
        {
            String res;
            switch(col)
            {
                case (ManaColor.White): res = "W"; break;
                case (ManaColor.Blue): res = "U"; break;
                case (ManaColor.Black): res = "B"; break;
                case (ManaColor.Red): res = "R"; break;
                case (ManaColor.Green): res = "G"; break;
                default: res = "1"; break;
            }

            return res;
        }

        public static String ColorListToShortenedString(IEnumerable<ManaColor> cols)
        {
            String res = "";
            foreach(ManaColor mc in cols)
            {
                res += ColorToShortenedString(mc);
            }

            return res;
        }

        public static Boolean CanBlockAttacker(Card Blocker, Card Attacker)
        {
            return true;
        }
    }
}
