using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Commands;
using Sharpening2020.Players;

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

        public void FinishCombat()
        {
            foreach(Card attacker in AttackerToBlockersMap.Keys)
            {
                if(AttackerToBlockersMap[attacker].Count == 0)
                {
                    ICanBeAttacked ICBA = AttackerToTargetMap[attacker];

                    MyGame.MyExecutor.Do(new CommandDealDamage(ICBA.ID, attacker.CurrentCharacteristics.Power));
                }
            }
        }
    }
}
