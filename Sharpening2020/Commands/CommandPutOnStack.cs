using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandPutOnStack : CommandBase
    {
        public readonly LazyGameObject<Card> CardID;
        public readonly Int32 ActivatableIndex;

        public CommandPutOnStack(Int32 cid, Int32 aind)
        {
            CardID = new LazyGameObject<Card>(cid);
            ActivatableIndex = aind;
        }

        public override void Do(Game g)
        {
            Activatable act = CardID.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex];

            StackInstance si = new StackInstance(act);
            g.RegisterGameObject(si);
            siID = si.ID;

            g.SpellStack.Push(new LazyGameObject<StackInstance>(si));
        }

        private Int32 siID;

        public override void Undo(Game g)
        {
            g.SpellStack.Pop();
            g.GameObjects.RemoveAll(x => { return x.ID == siID; });
        }

        public override object Clone()
        {
            return new CommandPutOnStack(CardID.ID, ActivatableIndex);
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
