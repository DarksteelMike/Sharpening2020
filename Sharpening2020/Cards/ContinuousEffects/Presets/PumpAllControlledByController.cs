using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Commands;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.ContinuousEffects.Presets
{
    public class PumpAllControlledByController : ContinuousEffect
    {
        public PumpAllControlledByController(LazyGameObject<Card> h)
        {
            Host = h;
        }
        public override bool Applies(Game g)
        {
            return true;
        }

        public override void Do(Game g)
        {
            executedCommands.Clear();
            foreach (LazyGameObject<Card> c in Host.Value(g).Controller.Value(g).MyZones[ZoneType.Battlefield].Contents.Where(x => { return x.Value(g).CurrentCharacteristics.CardTypes.Contains("Creature"); }))
            {
                executedCommands.Add(new CommandAddPowerToughness(c.ID, 1, 1));
            }

            foreach (CommandBase cb in executedCommands)
                cb.Do(g);
        }

        private List<CommandBase> executedCommands = new List<CommandBase>();

        public override void Undo(Game g)
        {
            if(g.DebugFlag.Contains(DebugMode.ContinuousEffects))
            {
                g.DebugAlert("Undoing PumpAllControlledByController");
            }

            foreach (CommandBase cb in executedCommands)
            {
                g.DebugAlert("     Undoing " + cb.ToString(g));
                cb.Undo(g);
            }
                
        }

        public override void UpdateViews(Game g)
        {
            foreach (CommandBase cb in executedCommands)
                cb.UpdateViews(g);
        }

        public override object Clone()
        {
            return new PumpAllControlledByController(Host);
        }
    }
}
