using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Sharpening2020.InputBridges;
using Sharpening2020.Players;

namespace Sharpening2020.Input
{
    public class InputHandler
    {
        public readonly LazyGameObject<Player> AssociatedPlayer;

        public InputBridge Bridge;

        public Game MyGame;
        
        public List<InputBase> InputList = new List<InputBase>();

        private InputBase bottomState = new WaitingForOpponent();

        public InputBase CurrentInputState
        {
            get 
                { return InputList.Count == 0 ? bottomState : InputList.Last(); }
            set
            {
                InputList.Add(value);

                //CurrentInputState.Enter();

                Bridge.SelectActionFromList(CurrentInputState.GetActions());
            }
        }

        public InputHandler(Game g, LazyGameObject<Player> p, InputBridge br)
        {
            MyGame = g;
            AssociatedPlayer = p;
            Bridge = br;
        }

    }
}
