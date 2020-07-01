using System;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Commands;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Phases
{
    public class PhaseHandler : ICloneable
    {
        public Game MyGame;
        public List<PhaseBase> AllPhases = new List<PhaseBase>();
        private Int32 currentPhaseIndex = 3;
        public Int32 CurrentPhaseIndex
        {
            get { return currentPhaseIndex; }
            set {
                Boolean ShouldDoPhaseEffects = false;
                if(currentPhaseIndex < value)
                {
                    ShouldDoPhaseEffects = true;
                }
                currentPhaseIndex = value;
                if(currentPhaseIndex >= AllPhases.Count)
                {
                    while (currentPhaseIndex >= AllPhases.Count)
                    {
                        currentPhaseIndex -= AllPhases.Count;
                    }

                    foreach(LazyGameObject<Card> c in MyGame.ActivePlayer.MyZones[ZoneType.Battlefield].Contents)
                    {
                        if(c.Value(MyGame).HasSummoningSickness)
                        {
                            MyGame.MyExecutor.Do(new CommandSetSummoningSickness(c.ID, false));
                        }
                    }
                }

                foreach (Player p in MyGame.GetPlayers())
                {
                    if (p.ManaPool.Count != 0)
                        MyGame.MyExecutor.Do(new CommandClearManaPool(p.ID));
                }

                while (currentPhaseIndex < 0)
                {
                    currentPhaseIndex += AllPhases.Count;
                }

                if (ShouldDoPhaseEffects)
                {
                    CurrentPhase.DoPhaseEffects(MyGame);
                    if (!CurrentPhase.ShouldGivePriority)
                    {
                        MyGame.MyExecutor.Do(new CommandAdvancePhase());
                    }
                    
                }

                if(MyGame.DebugFlag.Contains(DebugMode.Phases))
                {
                    MyGame.DebugAlert("Entering phase " + CurrentPhase.MyType.ToString());
                }

                MyGame.UpdatePhase();

                if (!CurrentPhase.ShouldGivePriority)
                {
                    currentPhaseIndex++;
                }
                else
                {
                    MyGame.PlayerWithPriorityIndex = MyGame.ActivePlayerIndex;
                }
            }
        }

        public PhaseBase CurrentPhase
        {
            get { return AllPhases[currentPhaseIndex]; }
        }

        public PhaseHandler()
        {
            AllPhases.Add(new PhaseUntap());
            AllPhases.Add(new PhaseUpkeep());
            AllPhases.Add(new PhaseDraw());
            AllPhases.Add(new PhasePreCombatMain());
            AllPhases.Add(new PhasePostCombatMain());
            AllPhases.Add(new PhaseEndOfTurn());
            AllPhases.Add(new PhaseCleanup());
        }

        public void EnterCurrentPhase()
        {
            AllPhases[currentPhaseIndex].DoPhaseEffects(MyGame);
        }

        public void UpdateGameReference(Game NewReference)
        {
            MyGame = NewReference;
        }

        public object Clone()
        {
            PhaseHandler ret = new PhaseHandler();
            ret.currentPhaseIndex = this.currentPhaseIndex;

            return ret;
        }
    }
}
