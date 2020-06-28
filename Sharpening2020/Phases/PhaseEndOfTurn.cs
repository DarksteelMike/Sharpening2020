using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Phases
{
    public class PhaseEndOfTurn : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.EndOfTurn; } }
        public override void DoPhaseEffects(Game g)
        {

        }
    }
}
