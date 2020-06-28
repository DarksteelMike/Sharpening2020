using System;
using System.Collections.Generic;

using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandResetTargets : CommandBase
    {
        public Int32 PlayerID;

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
