using System;
using System.Collections.Generic;

using Sharpening2020.Input;
using Sharpening2020.Phases;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020.InputBridges
{
    class NetworkBridge : InputBridge
    {
        //Really just a placeholder for now.
        public override GameAction SelectActionFromList(List<GameAction> actions)
        {
            System.Threading.Thread.Sleep(1000);
            throw new NotImplementedException();
        }

        public override void Prompt(string message)
        {
            throw new NotImplementedException();
        }

        public override void UpdateCardView(CardView view)
        {
            throw new NotImplementedException();
        }

        public override void UpdatePlayerView(PlayerView view)
        {
            throw new NotImplementedException();
        }

        public override void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            throw new NotImplementedException();
        }

        public override void UpdateStackView(List<StackInstanceView> views)
        {
            throw new NotImplementedException();
        }

        public override void DebugAlert(string msg)
        {
            throw new NotImplementedException();
        }

        public override void UpdatePhase(PhaseType pt)
        {
            throw new NotImplementedException();
        }
    }
}
