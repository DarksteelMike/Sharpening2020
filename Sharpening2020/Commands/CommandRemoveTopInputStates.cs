using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandRemoveTopInputStates : CommandBase
    {
        public readonly Int32 PlayerID;
        public readonly Int32 Amount;

        public CommandRemoveTopInputStates(Int32 pid, Int32 amt = 1)
        {
            PlayerID = pid;
            Amount = amt;
        }

        public override void Do(Game g)
        {
            if(g.DebugFlag == DebugMode.InputStates)
            {
                g.DebugAlert("RemoveTopInputStates(" + PlayerID + "," + Amount + ")\n");
                g.DebugAlert("InputList Count: " + g.InputHandlers[PlayerID].InputList.Count.ToString() + "\n");
                foreach (InputStateBase isb in g.InputHandlers[PlayerID].InputList)
                {
                    g.DebugAlert(isb.ToString() + "\n");
                }
            }

            prevStates = new List<InputStateBase>();
            for (Int32 i=0; i < Amount;i++)
            {
                InputStateBase state = g.InputHandlers[PlayerID].InputList.Last();
                prevStates.Add(state);
                state.Leave();
                g.InputHandlers[PlayerID].InputList.Remove(state);
            }
            prevStates.Reverse();
        }

        private List<InputStateBase> prevStates;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].InputList.AddRange(prevStates);
        }

        public override object Clone()
        {
            return new CommandRemoveTopInputStates(PlayerID,Amount);
        }
    }
}
