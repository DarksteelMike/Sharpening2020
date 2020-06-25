using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Phases
{
    class PhaseCleanup : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.Cleanup; } }
        public override void PhaseEffects(Game g)
        {

        }
    }
}
