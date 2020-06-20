using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandPutOnStack : CommandBase
    {
        public readonly Int32 CardID;
        public readonly Int32 ActivatableIndex;

        public CommandPutOnStack(Int32 cid, Int32 aind)
        {
            CardID = cid;
            ActivatableIndex = aind;
        }

        public override void Do(Game g)
        {
            Card host = (Card)g.GetGameObjectByID(CardID);
            Activatable act = host.CurrentCharacteristics.Activatables[ActivatableIndex];

            si = new StackInstance(act);
            g.RegisterGameObject(si);
            
            g.SpellStack.Push(new LazyGameObject<StackInstance>(si));
        }

        private StackInstance si;

        public override void Undo(Game g)
        {
            g.SpellStack.Pop();
            g.GameObjects.Remove(si);
        }

        public override object Clone()
        {
            return new CommandPutOnStack(CardID, ActivatableIndex);
        }

        public override void UpdateViews(Game g)
        {
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateStackView(g.GetStackView());
            }
        }
    }
}
