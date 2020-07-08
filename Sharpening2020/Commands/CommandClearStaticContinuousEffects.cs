using System.Collections.Generic;

using Sharpening2020.Cards.ContinuousEffects;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandClearStaticContinuousEffects : CommandBase
    {
        public override void Do(Game g)
        {
            prev = new List<ContinuousEffect>();

            prev.AddRange(g.MyContinuousEffects.StaticEffects);

            g.MyContinuousEffects.StaticEffects.Clear();
        }

        List<ContinuousEffect> prev;

        public override void Undo(Game g)
        {
            g.MyContinuousEffects.StaticEffects.AddRange(prev);

            foreach (ContinuousEffect ce in prev)
            {
                ce.Do(g);

                ce.UpdateViews(g);
            }
        }

        public override object Clone()
        {
            return new CommandClearStaticContinuousEffects();
        }

    }
}
