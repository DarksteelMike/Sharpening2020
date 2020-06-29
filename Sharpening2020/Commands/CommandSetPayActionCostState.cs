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
        public readonly Int32 ActivatableIndex;

        public CommandSetPayActionCostState(Int32 pid, Int32 cid, Int32 index)
        {
            PlayerID = pid;
            CardID = cid;
            ActivatableIndex = index;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            pac = new PayActionCost(act);

            g.InputHandlers[PlayerID].CurrentInputState = pac;
        }

        PayActionCost pac;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].RemoveInputFromList(pac);
        }

        public override object Clone()
        {
            return new CommandSetPayActionCostState(PlayerID, CardID, ActivatableIndex);
        }
    }
}
