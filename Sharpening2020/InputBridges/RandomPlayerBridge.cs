using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

namespace Sharpening2020.InputBridges
{
    public class RandomPlayerBridge : InputBridge
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

        public override void UpdateCardView(CardView view)
        {

        }

        public override void UpdatePlayerView(PlayerView view)
        {
            throw new NotImplementedException();
        }

        public override void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            throw new NotImplementedException();
        }

        public override void UpdateStackView(List<StackInstanceView> views)
        {
            throw new NotImplementedException();
        }
    }
}
