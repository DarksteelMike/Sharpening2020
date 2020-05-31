using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.InputBridges;
using Sharpening2020.Players;

namespace Sharpening2020.Input
{
    public class InputHandler
    {
        public readonly LazyGameObject<Player> AssociatedPlayer;

        public InputBridge Bridge;

        public Game MyGame;
        
        public List<InputBase> InputStack = new List<InputBase>();

        private InputBase bottomState = new WaitingForOpponent();

        public InputBase CurrentInputState
        {
            get 
                { return InputStack.Count == 0 ? bottomState : InputStack.Last(); }
            set
            {
                InputStack.Add(value);
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
