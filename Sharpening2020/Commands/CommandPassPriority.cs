using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    public class CommandPassPriority : CommandBase
    {
        public override void Do(Game g)
        {
            g.PlayersPassedInSuccession++;
            g.PlayerWithPriorityIndex++;
        }

        public override void Undo(Game g)
        {
            g.PlayersPassedInSuccession--;
            g.PlayerWithPriorityIndex--;
        }

        public override object Clone()
        {
            return new CommandPassPriority();
        }
    }
}
