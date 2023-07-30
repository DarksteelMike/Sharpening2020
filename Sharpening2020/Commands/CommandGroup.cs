using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Commands
{
    [Serializable]
    class CommandGroup2 : CommandBase
    {
        private readonly IReadOnlyList<CommandBase> SubCommands;

        public CommandGroup2(params CommandBase[] coms)
        {
            List<CommandBase> subs = new List<CommandBase>();

            subs.AddRange(coms);

            SubCommands = subs.AsReadOnly();
        }

        public override void Do(Game g)
        {
            foreach(CommandBase com in SubCommands)
            {
                g.MyExecutor.Do(com);
            }
        }

        public override void Undo(Game g)
        {
            //No need
        }

        public override object Clone()
        {
            return new CommandGroup2(SubCommands.Select(x => { return (CommandBase)x.Clone(); }).ToArray());
        }
    }
}
