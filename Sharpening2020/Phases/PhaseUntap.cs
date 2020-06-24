using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Commands;
using Sharpening2020.Zones;

namespace Sharpening2020.Phases
{
    class PhaseUntap : PhaseBase
    {
        public override void PhaseEffects(Game g)
        {
            foreach (Card c in g.GetCards(ZoneType.Battlefield, g.ActivePlayer).Where(x => x.IsTapped))
            {
                g.MyExecutor.Do(new CommandUntap(c.ID));
            }
        }
    }
}
