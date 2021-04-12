using System;

using Sharpening2020.Attributes;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    class CommandSetTargetState : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;
        [ProtoMember(2)]
        public readonly Int32 CardID;
        [ProtoMember(3)]
        public readonly Int32 Index;
        [ProtoMember(4)]
        public readonly AbilityType Mode;

        private CommandSetTargetState() { }

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
