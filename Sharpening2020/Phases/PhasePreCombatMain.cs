using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Phases
{
    public class PhasePreCombatMain : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.PreCombatMain; } }
        public override void PhaseEffects(Game g)
        {
        }
    }
}
