using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Commands;

namespace Sharpening2020.Combat
{
    public class CombatHandler
    {
        public Game MyGame;
        public readonly Dictionary<Card, ICanBeAttacked> AttackerToTargetMap = new Dictionary<Card, ICanBeAttacked>();
        public readonly Dictionary<Card, List<Card>> AttackerToBlockersMap = new Dictionary<Card, List<Card>>();

        public void Reset()
        {
            AttackerToTargetMap.Clear();
            AttackerToBlockersMap.Clear();
        }

        public Boolean IsValid()
        {
            return true;
        }

        public void FinishCombat()
        {
            
        }
    }
}
