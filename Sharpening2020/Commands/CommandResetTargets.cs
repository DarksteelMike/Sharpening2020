﻿using System;
using System.Collections.Generic;

using Sharpening2020.Attributes;
using Sharpening2020.Input;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    //This command clears the targets from the currently targeting activatable.
    class CommandResetTargets : CommandBase
    {
        [ProtoMember(1)]
        public Int32 PlayerID;

        private CommandResetTargets() { }

        public CommandResetTargets(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            SetTargets st = (SetTargets)g.InputHandlers[PlayerID].CurrentInputState;

            prev = new List<GameObject>();
            prev.AddRange(st.MyActivatable.MyTargeting.Targeted);

            st.MyActivatable.MyTargeting.Targeted.Clear();
        }

        List<GameObject> prev;

        public override void Undo(Game g)
        {
            SetTargets st = (SetTargets)g.InputHandlers[PlayerID].CurrentInputState;

            prev = new List<GameObject>();
            prev.AddRange(st.MyActivatable.MyTargeting.Targeted);

            st.MyActivatable.MyTargeting.Targeted.Clear();
        }

        public override object Clone()
        {
            return new CommandResetTargets(PlayerID);
        }
    }
}
