using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                }                

                while(currentPhaseIndex < 0)
                {
                    currentPhaseIndex += AllPhases.Count;
                }

                if (ShouldDoPhaseEffects)
                    CurrentPhase.PhaseEffects(MyGame);

                MyGame.UpdatePhase();
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
            AllPhases[currentPhaseIndex].PhaseEffects(MyGame);
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
