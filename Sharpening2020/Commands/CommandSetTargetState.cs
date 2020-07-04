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
        public readonly Int32 Index;
        public readonly AbilityType Mode;

        public CommandSetTargetState(Int32 pid, Int32 cid, Int32 aind, AbilityType m)
        {
            PlayerID = pid;
            CardID = cid;
            Index = aind;
            Mode = m;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = null;
            if (Mode == AbilityType.Activatable)
            {
                act = c.CurrentCharacteristics.Activatables[Index];
            }
            else if(Mode == AbilityType.Trigger)
            {
                act = c.CurrentCharacteristics.Triggers[Index].myAbility;
            }

            st = new SetTargets(act, Mode);

            g.InputHandlers[PlayerID].CurrentInputState = st;
        }

        private SetTargets st;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].RemoveInputFromList(st);
        }

        public override object Clone()
        {
            return new CommandSetTargetState(PlayerID, CardID, Index, Mode);
        }
    }
}
