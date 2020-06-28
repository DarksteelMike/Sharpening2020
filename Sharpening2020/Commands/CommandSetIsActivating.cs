using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Commands
{
    class CommandSetIsActivating : CommandBase
    {
        public readonly Int32 CardID;
        public readonly Int32 ActivatableIndex;
        public readonly Boolean Mode;

        public CommandSetIsActivating(Int32 cid, Int32 aind, Boolean m)
        {
            CardID = cid;
            ActivatableIndex = aind;
            Mode = m;
        }

        public override void Do(Game g)
        {
            Card host = (Card)g.GetGameObjectByID(CardID);
            Activatable act = host.CurrentCharacteristics.Activatables[ActivatableIndex];

            act.IsBeingActivated = Mode;
        }

        public override void Undo(Game g)
        {
            Card host = (Card)g.GetGameObjectByID(CardID);
            Activatable act = host.CurrentCharacteristics.Activatables[ActivatableIndex];

            act.IsBeingActivated = !Mode;
        }

        public override object Clone()
        {
            return new CommandSetIsActivating(CardID, ActivatableIndex, Mode);
        }
    }
}
