using System;
using System.Collections.Generic;

using Sharpening2020.Input;
using Sharpening2020.Views;

namespace Sharpening2020.InputBridges
{
    public abstract class InputBridge
    {
        public abstract GameAction SelectActionFromList(List<GameAction> actions);

        public abstract void Prompt(String message);

        public abstract void UpdateView(ViewObject view);
    }
}
