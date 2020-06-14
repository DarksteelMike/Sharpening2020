using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

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

            StackInstance si = new StackInstance(act);
            g.RegisterGameObject(si);

            siID = si.ID;

            g.SpellStack.Push(si);
        }

        private Int32 siID;

        public override void Undo(Game g)
        {
            g.SpellStack.Pop();
        }

        public override object Clone()
        {
            return new CommandPutOnStack(CardID, ActivatableIndex);
        }
    }
}
