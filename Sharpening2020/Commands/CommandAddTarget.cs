using System;

using Sharpening2020.Input;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandAddTarget : CommandBase
    {
        public readonly Int32 TargeterID;
        public readonly Int32 ObjectID;

        public CommandAddTarget(Int32 tid, Int32 oid)
        {
            TargeterID = tid;
            ObjectID = oid;
        }

        public override void Do(Game g)
        {
            InputHandler IH = g.InputHandlers[TargeterID];
            SetTargets st = (SetTargets)IH.CurrentInputState;
            go = g.GetGameObjectByID(ObjectID);

            st.MyActivatable.MyTargeting.Targeted.Add(go);
        }
        
        private GameObject go;

        public override void Undo(Game g)
        {
            InputHandler IH = g.InputHandlers[TargeterID];
            SetTargets st = (SetTargets)IH.CurrentInputState;

            st.MyActivatable.MyTargeting.Targeted.Remove(go);
        }

        public override object Clone()
        {
            return new CommandAddTarget(TargeterID, ObjectID);
        }
    }
}
