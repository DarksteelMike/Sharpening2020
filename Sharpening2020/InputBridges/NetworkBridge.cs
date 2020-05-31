using System;
using System.Collections.Generic;
using System.Net;

using Sharpening2020.Input;


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

        public override void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
