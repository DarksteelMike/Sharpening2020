using System;
using System.Collections.Generic;

using Sharpening2020.InputBridges;
using Sharpening2020.Players;

namespace Sharpening2020.Input
{
    public abstract class InputStateBase : ICloneable
    {
        public Player MyPlayer;
        public Game MyGame;
        public InputBridge MyBridge;

        public abstract List<GameAction> GetActions();

        public abstract void SelectAction(GameAction a);

        public void UpdateGameReference(Game g)
        {
            MyGame = g;
        }

        public abstract object Clone();

        public virtual void Enter() { }

        public virtual void Leave() { }
    }
}
