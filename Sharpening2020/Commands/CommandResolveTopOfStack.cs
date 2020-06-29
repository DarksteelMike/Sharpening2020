using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandResolveTopOfStack : CommandBase
    {
        public override void Do(Game g)
        {
            resolved = g.SpellStack.Pop();

            resolved.Value(g).Resolve(g);

            g.MyContinuousEffects.RunContinuousEffects();
        }

        private LazyGameObject<StackInstance> resolved;

        public override void Undo(Game g)
        {
            g.SpellStack.Push(resolved);

            //Commands performed by the stackinstance's resolution will have been undone already.
        }

        public override void UpdateViews(Game g)
        {
            foreach(InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateStackView(g.GetStackView());
            }
        }

        public override object Clone()
        {
            return new CommandResolveTopOfStack();
        }
    }
}
