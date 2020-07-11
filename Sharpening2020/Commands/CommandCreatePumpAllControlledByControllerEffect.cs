using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.ContinuousEffects.Presets;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandCreatePumpAllControlledByControllerEffect : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 SourceID;

        private CommandCreatePumpAllControlledByControllerEffect() { }

        public CommandCreatePumpAllControlledByControllerEffect(Int32 sid)
        {
            SourceID = sid;
        }

        public override void Do(Game g)
        {
            PumpAllControlledByController pacbm = new PumpAllControlledByController(new LazyGameObject<Card>(SourceID));
            g.MyContinuousEffects.StaticEffects.Add(pacbm);
        }

        public override void Undo(Game g)
        {
            g.MyContinuousEffects.StaticEffects.RemoveAt(g.MyContinuousEffects.StaticEffects.Count - 1);
        }

        public override object Clone()
        {
            return new CommandCreatePumpAllControlledByControllerEffect(SourceID);
        }
    }
}
