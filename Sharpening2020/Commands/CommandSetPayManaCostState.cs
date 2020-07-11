using System;

using Sharpening2020.Input;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandSetPayManaCostState : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 PlayerID;
        [ProtoMember(2)]
        public readonly Int32 CardID;
        [ProtoMember(3)]
        public readonly Int32 Index;
        [ProtoMember(4)]
        public readonly AbilityType Mode;

        private CommandSetPayManaCostState() { }

        public CommandSetPayManaCostState(Int32 pid, Int32 cid, Int32 index, AbilityType m)
        {
            PlayerID = pid;
            CardID = cid;
            Index = index;
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
            else if (Mode == AbilityType.Trigger)
            {
                act = c.CurrentCharacteristics.Triggers[Index].myAbility;
            }

            pmc = new PayManaCost(act, Mode);

            g.InputHandlers[PlayerID].CurrentInputState = pmc;
        }

        PayManaCost pmc;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].RemoveInputFromList(pmc);
        }

        public override object Clone()
        {
            return new CommandSetPayManaCostState(PlayerID, CardID, Index, Mode);
        }
    }
}
