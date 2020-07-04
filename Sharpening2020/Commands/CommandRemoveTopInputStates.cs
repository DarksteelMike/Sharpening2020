﻿using System;
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
            g.DebugAlert(DebugMode.InputStates, "RemoveTopInputStates(" + PlayerID + "," + Amount + ")\n");
            g.DebugAlert(DebugMode.InputStates, "InputList Count: " + g.InputHandlers[PlayerID].GetInputList().Count.ToString() + "\n");
            foreach (InputStateBase isb in g.InputHandlers[PlayerID].GetInputList())
            {
                g.DebugAlert(DebugMode.InputStates, isb.ToString() + "\n");
            }

            prevStates = new List<InputStateBase>();
            for (Int32 i=0; i < Amount;i++)
            {
                InputStateBase state = g.InputHandlers[PlayerID].GetInputList().Last();
                prevStates.Add(state);
                state.Leave();
                g.InputHandlers[PlayerID].RemoveInputFromList(state);
            }
            prevStates.Reverse();
        }

        private List<InputStateBase> prevStates;

        public override void Undo(Game g)
        {
            g.InputHandlers[PlayerID].GetInputList().AddRange(prevStates);
        }

        public override object Clone()
        {
            return new CommandRemoveTopInputStates(PlayerID,Amount);
        }
    }
}
