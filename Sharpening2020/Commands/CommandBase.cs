using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Mana;
using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [ProtoInclude(1, typeof(CommandAddAttacker))]
    [ProtoInclude(2, typeof(CommandAddBlocker))]
    [ProtoInclude(3, typeof(CommandAddCounter))]
    [ProtoInclude(4, typeof(CommandAddManaToPool))]
    [ProtoInclude(5, typeof(CommandAddPowerToughness))]
    [ProtoInclude(6, typeof(CommandAddTarget))]
    [ProtoInclude(7, typeof(CommandAdvancePhase))]
    [ProtoInclude(8, typeof(CommandAssignDamage))]
    [ProtoInclude(9, typeof(CommandClearInputList))]
    [ProtoInclude(10, typeof(CommandClearManaPool))]
    [ProtoInclude(11, typeof(CommandClearStaticContinuousEffects))]
    [ProtoInclude(12, typeof(CommandCreateCard))]
    [ProtoInclude(13, typeof(CommandCreatePlayer))]
    [ProtoInclude(14, typeof(CommandCreatePumpAllControlledByControllerEffect))]
    [ProtoInclude(15, typeof(CommandCreateStaticPumpEffect))]
    [ProtoInclude(16, typeof(CommandDealDamage))]
    [ProtoInclude(17, typeof(CommandDestroy))]
    [ProtoInclude(18, typeof(CommandDrawCard))]
    [ProtoInclude(19, typeof(CommandEnterInputState))]
    [ProtoInclude(20, typeof(CommandGainLife))]
    [ProtoInclude(21, typeof(CommandIncrementActionPartIndex))]
    [ProtoInclude(22, typeof(CommandIncrementActivePlayerIndex))]
    [ProtoInclude(23, typeof(CommandIncrementLandsPlayed))]
    [ProtoInclude(24, typeof(CommandLoseLife))]
    [ProtoInclude(25, typeof(CommandMarker))]
    [ProtoInclude(26, typeof(CommandMoveCard))]
    [ProtoInclude(27, typeof(CommandPassPriority))]
    [ProtoInclude(28, typeof(CommandPayMana))]
    [ProtoInclude(29, typeof(CommandPerformActionCost))]
    [ProtoInclude(30, typeof(CommandPutOnStack))]
    [ProtoInclude(31, typeof(CommandRemoveAttacker))]
    [ProtoInclude(32, typeof(CommandRemoveBlocker))]
    [ProtoInclude(33, typeof(CommandRemoveCounter))]
    [ProtoInclude(34, typeof(CommandRemoveGameObjectFromGame))]
    [ProtoInclude(35, typeof(CommandRemoveTopInputStates))]
    [ProtoInclude(36, typeof(CommandResetActionCost))]
    [ProtoInclude(37, typeof(CommandResetCardsDrawn))]
    [ProtoInclude(38, typeof(CommandResetLandsPlayed))]
    [ProtoInclude(39, typeof(CommandResetManaCost))]
    [ProtoInclude(40, typeof(CommandResetTargets))]
    [ProtoInclude(41, typeof(CommandResolveTopOfStack))]
    [ProtoInclude(42, typeof(CommandRunTriggers))]
    [ProtoInclude(43, typeof(CommandSacrifice))]
    [ProtoInclude(44, typeof(CommandSetAttackingState))]
    [ProtoInclude(45, typeof(CommandSetBlockingState))]
    [ProtoInclude(46, typeof(CommandSetCardState))]
    [ProtoInclude(47, typeof(CommandSetHavePriorityState))]
    [ProtoInclude(48, typeof(CommandSetPayActionCostState))]
    [ProtoInclude(49, typeof(CommandSetPayManaCostState))]
    [ProtoInclude(50, typeof(CommandSetSummoningSickness))]
    [ProtoInclude(51, typeof(CommandSetTargetState))]
    [ProtoInclude(52, typeof(CommandSetWaitingForOpponentsState))]
    [ProtoInclude(53, typeof(CommandShuffleLibrary))]
    [ProtoInclude(54, typeof(CommandSetIsTapped))]
    [ProtoInclude(55, typeof(CommandSetIsActivating))]
    public abstract class CommandBase : ICloneable
    {
        public abstract void Do(Game g);
        public abstract void Undo(Game g);
        public abstract object Clone();

        public virtual void UpdateViews(Game g) { }

        public String ToString(Game g)
        {
            String res = GetType().Name;
            IEnumerable<FieldInfo> parameters = GetType().GetFields().Where(x => { return x.IsInitOnly; });
            foreach (FieldInfo fi in parameters)
            {
                var ResultingValue = fi.GetValue(this);                    

                GameObject go = null;
                if(ResultingValue.GetType().Name.Equals(typeof(LazyGameObject<>).Name)) 
                {
                    if(ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(Card)))
                    {
                        go = ((LazyGameObject<Card>)ResultingValue).Value(g) as Card;
                    }
                    else if(ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(Player)))
                    {
                        go = ((LazyGameObject<Player>)ResultingValue).Value(g) as Player;
                    }
                    else if (ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(Counter)))
                    {
                        go = ((LazyGameObject<Counter>)ResultingValue).Value(g) as Counter;
                    }
                    else if (ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(StackInstance)))
                    {
                        go = ((LazyGameObject<StackInstance>)ResultingValue).Value(g) as StackInstance;
                    }
                    else if (ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(ManaPoint)))
                    {
                        go = ((LazyGameObject<ManaPoint>)ResultingValue).Value(g) as ManaPoint;
                    }
                }
                if(go != null)
                {
                    res += "(" + fi.Name + ":" + go.ToString(g) + ")";
                }
                else
                {
                    res += "(" + fi.Name + ":" + ResultingValue.ToString() + ")";
                }
            }

            return res;
        }
    }
}
