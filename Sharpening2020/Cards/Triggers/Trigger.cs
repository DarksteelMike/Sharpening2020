using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;

namespace Sharpening2020.Cards.Triggers
{
    public class Trigger
    {
        public Func<CommandBase, Game, Boolean> triggerOn;
        public Func<Trigger, Game, Boolean> canTrigger;
        public Ability myAbility;
        public LazyGameObject<Card> host;

        public Trigger(Func<CommandBase, Game, Boolean> pred, Func<Trigger, Game, Boolean> canTrig, Ability ab, LazyGameObject<Card> h)
        {
            triggerOn = pred;
            canTrigger = canTrig;
            myAbility = ab;
            host = h;
        }

        public Boolean CanTrigger(Game g)
        {
            if (canTrigger == null)
                return false;

            return canTrigger(this,g);
        }

        public Boolean ShouldTriggerOn(CommandBase com, Game g)
        {
            if (triggerOn == null)
                return false;

            return triggerOn(com, g);
        }

        public void DoTrigger(Game g)
        { 
            if(myAbility != null)
            {
                g.DebugAlert(DebugMode.Triggers, "Triggering for player ID " + host.Value(g).Controller.ID);
                CommandBase com = new CommandGroup(
                    new CommandMarker(CommandMarkerType.StartActivating),
                    new CommandSetIsActivating(host.ID, host.Value(g).CurrentCharacteristics.Triggers.IndexOf(this), true, AbilityType.Trigger),
                    new CommandSetTargetState(host.Value(g).Controller.ID, host.ID, host.Value(g).CurrentCharacteristics.Triggers.IndexOf(this), AbilityType.Trigger),
                    new CommandEnterInputState());

                g.MyExecutor.Do(com);
            }
        }

        public String ToString(Game g)
        {
            String res = "";
            res += host.Value(g).ToString(g) + " trigger [" + host.Value(g).CurrentCharacteristics.IndexOfAbility(myAbility, AbilityType.Trigger) + "]";
            return res;
        }
    }
}
