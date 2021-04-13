using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Input
{
    class WaitingForOpponent : InputStateBase
    {
        private List<GameAction> empty = new List<GameAction>();
        public override List<GameAction> GetActions()
        {
            return empty;
        }

        public override void Enter()
        {
            MyBridge.Prompt("Waiting for opponents.");
        }

        public override void SelectAction(GameAction a)
        {
            //Don't care.
        }

        public override object Clone()
        {
            return new WaitingForOpponent();
        }

        public override string ToString(Game g)
        {
            return "WaitingForOpponent";
        }
    }
}
