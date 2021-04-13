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
        
        public List<InputStateBase> InputList = new List<InputStateBase>();

        private InputStateBase bottomState = new WaitingForOpponent();

        public InputStateBase CurrentInputState
        {
            get 
                { return InputList.Count == 0 ? bottomState : InputList.Last(); }
            set
            {
                //CurrentInputState.Leave();

                AddInputState(value);

                CurrentInputState.MyGame = MyGame;
                CurrentInputState.MyBridge = Bridge;
                CurrentInputState.MyPlayer = AssociatedPlayer;
 
                MyGame.DebugAlert(DebugMode.InputStates, "Player " + AssociatedPlayer.ID + ": Added state \"" + value.ToString(MyGame) + "\"");
            }
        }

        public List<InputStateBase> GetInputList()
        {
            return InputList;
        }

        public void AddInputState(InputStateBase ib)
        {
            InputList.Add(ib);
        }

        public void RemoveInputFromList(InputStateBase ib)
        {
            InputList.Remove(ib);
        }

        public InputStateBase GetTopInput()
        {
            return InputList.Count == 0 ? bottomState : InputList.Last();
        }

        public void RemoveTopInput()
        {
            InputList.RemoveAt(InputList.Count - 1);
        }

        public void UpdateGameReferences(Game g)
        {
            foreach(InputStateBase ib in InputList)
            {
                ib.MyGame = g;
            }
        }

        public InputHandler(Game g, LazyGameObject<Player> p, InputBridge br)
        {
            MyGame = g;
            AssociatedPlayer = p;
            Bridge = br;
            bottomState.MyGame = MyGame;
            bottomState.MyBridge = Bridge;
            bottomState.MyPlayer = AssociatedPlayer;
        }

    }
}
