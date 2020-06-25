using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Phases
{
    public class PhaseUpkeep : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Upkeep; } }
        public override void PhaseEffects(Game g)
        {

        }
    }
}
