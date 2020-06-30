using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    class CommandMarkerStartActivating : CommandBase
    {
        public override void Do(Game g)
        {
        }

        public override void Undo(Game g)
        {
        }

        public override object Clone()
        {
            return new CommandMarkerStartActivating();
        }
    }
}
