using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command puts a specific activatable of a specific card on the stack.
    class CommandPutOnStack : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> CardID;
        [ProtoMember(2)]
        public readonly Int32 ActivatableIndex;
        [ProtoMember(3)]
        public readonly AbilityType Mode;

        private CommandPutOnStack() { }

        public CommandPutOnStack(Int32 cid, Int32 aind, AbilityType m)
        {
            CardID = new LazyGameObject<Card>(cid);
            ActivatableIndex = aind;
            Mode = m;
        }

        public override void Do(Game g)
        {
            Activatable act = null;

            if (Mode == AbilityType.Activatable)
            {
                act = CardID.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex];
            }
            else if(Mode == AbilityType.Replacement)
            {
                //TODO?
            }
            else
            {
                act = CardID.Value(g).CurrentCharacteristics.Triggers[ActivatableIndex].myAbility;
            }

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
            return new CommandPutOnStack(CardID.ID, ActivatableIndex, Mode);
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
