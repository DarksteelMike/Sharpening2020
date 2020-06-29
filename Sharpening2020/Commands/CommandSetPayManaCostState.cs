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
        public readonly Int32 ActivatableIndex;

        public CommandSetPayManaCostState(Int32 pid, Int32 cid, Int32 index)
        {
            PlayerID = pid;
            CardID = cid;
            ActivatableIndex = index;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            pmc = new PayManaCost(act);

            g.InputHandlers[PlayerID].CurrentInputState = pmc;
        }

        PayManaCost pmc;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].RemoveInputFromList(pmc);
        }

        public override object Clone()
        {
            return new CommandSetPayManaCostState(PlayerID, CardID, ActivatableIndex);
        }
    }
}
