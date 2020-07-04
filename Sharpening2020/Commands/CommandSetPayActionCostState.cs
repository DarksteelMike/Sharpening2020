using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandSetPayActionCostState : CommandBase
    {
        public readonly Int32 PlayerID;
        public readonly Int32 CardID;
        public readonly Int32 Index;
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
