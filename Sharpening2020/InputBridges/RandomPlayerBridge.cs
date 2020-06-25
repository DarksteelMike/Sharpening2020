using System;
using System.Collections.Generic;

using Sharpening2020.Input;
using Sharpening2020.Phases;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020.InputBridges
{
    public class RandomPlayerBridge : InputBridge
    {
        Random rand = new Random();

        public override GameAction SelectActionFromList(List<GameAction> actions)
        {
            if (actions.Count == 0)
                return null;

            return actions[rand.Next(0, actions.Count)];
        }

        public override void Prompt(string message)
        {
            //Don't care
        }

        public override void UpdateCardView(CardView view)
        {
            //Don't care
        }

        public override void UpdatePlayerView(PlayerView view)
        {
            //Don't care
        }

        public override void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            //Don't care
        }

        public override void UpdateStackView(List<StackInstanceView> views)
        {
            //Don't care
        }

        public override void DebugAlert(string msg)
        {
            //Don't care
        }

        public override void UpdatePhase(PhaseType pt)
        {
            //Don't care
        }
    }
}
