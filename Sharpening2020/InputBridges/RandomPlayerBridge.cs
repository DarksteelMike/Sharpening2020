using System;
using System.Collections.Generic;

using Sharpening2020.Input;

namespace Sharpening2020.InputBridges
{
    class RandomPlayerBridge : InputBridge
    {
        Random rand = new Random();
        public override GameAction SelectActionFromList(List<GameAction> actions)
        {
            return actions[rand.Next(0, actions.Count)];
        }

        public override void Prompt(string message)
        {
            //Don't care
        }

        public override void UpdateView()
        {
            //Don't care
        }
    }
}
