using System;
using System.Collections.Generic;

using Sharpening2020.Commands;

namespace Sharpening2020.Cards.Triggers
{
    public class TriggerHandler
    {
        public Game MyGame;

        public Boolean SuspendTriggers = false;

        public readonly List<Trigger> WaitingTriggers = new List<Trigger>();

        public void RunTriggers() 
        {
            if(SuspendTriggers)
            {
                MyGame.DebugAlert(DebugMode.Triggers, "Triggers are suspended! Aborting..");
                return;
            }

            while(WaitingTriggers.Count != 0)
            {
                Trigger t = WaitingTriggers[0];
                WaitingTriggers.RemoveAt(0);

                t.DoTrigger(MyGame);
            }
        }

        public void GatherTriggers(CommandBase triggerEvent)
        {
            if (SuspendTriggers)
            {
                MyGame.DebugAlert(DebugMode.Triggers, "Triggers are suspended! Aborting..");
                return;
            }

            foreach (Card c in MyGame.GetCards())
            {
                foreach(Trigger t in c.CurrentCharacteristics.Triggers)
                {
                    if(!t.myAbility.IsBeingActivated && t.CanTrigger(MyGame) && t.ShouldTriggerOn(triggerEvent, MyGame))
                    {
                        MyGame.DebugAlert(DebugMode.Triggers, "Triggered \"" + t.ToString(MyGame) + "\"");
                        WaitingTriggers.Add(t);                 
                    }
                    else
                    {
                        MyGame.DebugAlert(DebugMode.Triggers, "Trigger \"" + t.ToString(MyGame) + "\" can't trigger on " + triggerEvent.ToString(MyGame));
                    }
                }
            }
        }
    }
}
