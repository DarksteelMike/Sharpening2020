using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandSetTargetState : CommandBase
    {
        public readonly Int32 PlayerID;
        public readonly Int32 CardID;
        public readonly Int32 ActivatableIndex;

        public CommandSetTargetState(Int32 pid, Int32 cid, Int32 aind)
        {
            PlayerID = pid;
            CardID = cid;
            ActivatableIndex = aind;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            st = new SetTargets(act);

            g.InputHandlers[PlayerID].CurrentInputState = st;
        }

        private SetTargets st;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].InputList.Remove(st);
        }

        public override object Clone()
        {
            return new CommandSetTargetState(PlayerID, CardID, ActivatableIndex);
        }
    }
}
