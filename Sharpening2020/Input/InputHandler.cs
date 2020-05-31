using System;

using Sharpening2020.InputBridges;
using Sharpening2020.Players;

namespace Sharpening2020.Input
{
    public class InputHandler
    {
        public readonly LazyGameObject<Player> AssociatedPlayer;

        public InputBridge Bridge;

        public Game MyGame;

        public InputBase currentInputState = new WaitingForOpponent();

        public InputBase CurrentInputState
        {
            get { return currentInputState; }
            set
            {
                currentInputState = value;
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
