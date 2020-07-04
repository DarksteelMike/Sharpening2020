using System;

using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Commands
{
    class CommandSetPayManaCostState : CommandBase
    {
        public readonly Int32 PlayerID;
        public readonly Int32 CardID;
        public readonly Int32 Index;
        public readonly AbilityType Mode;

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
