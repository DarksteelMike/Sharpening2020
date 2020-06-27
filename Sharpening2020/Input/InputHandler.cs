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
        
        public List<InputStateBase> InputList = new List<InputStateBase>();

        private InputStateBase bottomState = new WaitingForOpponent();

        public InputStateBase CurrentInputState
        {
            get 
                { return InputList.Count == 0 ? bottomState : InputList.Last(); }
            set
            {
                CurrentInputState.Leave();

                InputList.Add(value);

                CurrentInputState.MyGame = MyGame;
                CurrentInputState.MyBridge = Bridge;
                CurrentInputState.MyPlayer = AssociatedPlayer;

                if(!(CurrentInputState is WaitingForOpponent))
                    CurrentInputState.SelectAction(Bridge.SelectActionFromList(CurrentInputState.GetActions()));
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
