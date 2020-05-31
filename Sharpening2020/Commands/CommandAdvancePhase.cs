using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    public class CommandAdvancePhase : CommandBase
    {
        public override void Do(Game g)
        {
            g.MyPhaseHandler.CurrentPhaseIndex++;
        }

        public override void Undo(Game g)
        {
            g.MyPhaseHandler.CurrentPhaseIndex--;
        }

        public override object Clone()
        {
            return new CommandAdvancePhase();
        }
    }
}
