using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    class CommandIncrementActivePlayerIndex : CommandBase
    {
        public override void Do(Game g)
        {
            g.ActivePlayerIndex++;
        }

        public override void Undo(Game g)
        {
            g.ActivePlayerIndex--;
        }

        public override object Clone()
        {
            return new CommandIncrementActivePlayerIndex();
        }
    }
}
