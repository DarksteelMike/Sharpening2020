using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    public enum CommandMarkerType { StartActivating, GetPriority }
    class CommandMarker : CommandBase
    {
        public readonly CommandMarkerType MyType;

        public CommandMarker(CommandMarkerType type)
        {
            MyType = type;
        }

        public override void Do(Game g)
        {
        }

        public override void Undo(Game g)
        {
        }

        public override object Clone()
        {
            return new CommandMarker(MyType);
        }
    }
}
