using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Phases
{
    class PhaseBeginCombat : PhaseBase
    {
        public override PhaseType MyType { get { return PhaseType.BeginCombat; } }
    }
}
