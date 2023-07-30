
using Sharpening2020.Attributes;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    //This command makes all players Enter() their current input state.
    class CommandEnterInputState : CommandBase
    {
        public override void Do(Game g)
        {
            foreach(InputHandler ih in g.InputHandlers.Values)
            {
                if(ih.CurrentInputState is WaitingForOpponent)
                    ih.CurrentInputState.Enter();
            }
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                if (!(ih.CurrentInputState is WaitingForOpponent))
                    ih.CurrentInputState.Enter();
            }
        }

        public override void Undo(Game g)
        {
            //Nothing to do here.
        }

        public override object Clone()
        {
            return new CommandEnterInputState();
        }
    }
}
