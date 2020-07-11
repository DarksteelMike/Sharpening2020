using System;

using Sharpening2020.Cards.ContinuousEffects.Presets;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandCreateStaticPumpEffect : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 CardID;
        [ProtoMember(2)]
        public readonly Int32 Power;
        [ProtoMember(3)]
        public readonly Int32 Toughness;

        private CommandCreateStaticPumpEffect() { }

        public CommandCreateStaticPumpEffect(Int32 cid, Int32 p, Int32 t)
        {
            CardID = cid;
            Power = p;
            Toughness = t;
        }

        public override void Do(Game g)
        {
            g.MyContinuousEffects.StaticEffects.Add(new PumpPT(CardID, Power, Toughness,g.NextTimeStamp++));
        }

        public override void Undo(Game g)
        {
            g.MyContinuousEffects.StaticEffects.RemoveAt(g.MyContinuousEffects.StaticEffects.Count - 1);
        }

        public override object Clone()
        {
            return new CommandCreateStaticPumpEffect(CardID, Power, Toughness);
        }
    }
}
