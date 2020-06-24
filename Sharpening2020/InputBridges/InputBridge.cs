using System;
using System.Collections.Generic;

using Sharpening2020.Input;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020.InputBridges
{
    public abstract class InputBridge
    {
        public abstract GameAction SelectActionFromList(List<GameAction> actions);

        public abstract void Prompt(String message);

        public abstract void UpdateCardView(CardView view);

        public abstract void UpdatePlayerView(PlayerView view);

        public abstract void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views);

        public abstract void UpdateStackView(List<StackInstanceView> views);

        public abstract void DebugAlert(String msg);
    }
}
