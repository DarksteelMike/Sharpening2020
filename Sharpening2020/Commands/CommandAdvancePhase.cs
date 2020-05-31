using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    public class CommandAdvancePhase : ICommand
    {
        public void Do(Game g)
        {
            g.MyPhaseHandler.CurrentPhaseIndex++;
        }

        public void Undo(Game g)
        {
            g.MyPhaseHandler.CurrentPhaseIndex--;
        }
    }
}
