using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Commands;
using Sharpening2020.Zones;

namespace Sharpening2020.Phases
{
    public class PhaseUpkeep : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Upkeep; } }
        public override void DoPhaseEffects(Game g)
        {
            foreach (Card c in g.GetCards(ZoneType.Battlefield, g.ActivePlayer).Where(x => x.HasSummoningSickness))
            {
                g.MyExecutor.Do(new CommandSetSummoningSickness(c.ID, false));
            }
        }
    }
}
