using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandSetPayActionCostState : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;
        [ProtoMember(2)]
        public readonly Int32 CardID;
        [ProtoMember(3)]
        public readonly Int32 Index;
        [ProtoMember(4)]
        public readonly AbilityType Mode;

        public CommandSetPayActionCostState(Int32 pid, Int32 cid, Int32 index, AbilityType m)
        {
            PlayerID = pid;
            CardID = cid;
            Index = index;
            Mode = m;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = null; ;

            if(Mode == AbilityType.Trigger)
            {
                act = c.CurrentCharacteristics.Triggers[Index].myAbility;
            }
            else if(Mode == AbilityType.Replacement)
            {

            }
            else
            {
                act = c.CurrentCharacteristics.Activatables[Index];
            }

            pac = new PayActionCost(act, Mode);

            g.InputHandlers[PlayerID].CurrentInputState = pac;
        }

        PayActionCost pac;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].RemoveInputFromList(pac);
        }

        public override object Clone()
        {
            return new CommandSetPayActionCostState(PlayerID, CardID, Index, Mode);
        }
    }
}
