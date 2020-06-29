using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandAddTarget : CommandBase
    {
        public readonly Int32 CardID;
        public readonly Int32 ActivatableIndex;
        public readonly Int32 TargetID;

        public CommandAddTarget(Int32 tid, Int32 aind, Int32 oid)
        {
            CardID = tid;
            ActivatableIndex = aind;
            TargetID = oid;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            go = g.GetGameObjectByID(TargetID);

            act.MyTargeting.Targeted.Add(go);
        }
        
        private GameObject go;

        public override void Undo(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            act.MyTargeting.Targeted.RemoveAt(act.MyTargeting.Targeted.Count - 1);
        }

        public override object Clone()
        {
            return new CommandAddTarget(CardID, ActivatableIndex, TargetID);
        }
    }
}
