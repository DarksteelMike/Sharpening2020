using System;

using Sharpening2020.Cards.ContinuousEffects.Presets;

namespace Sharpening2020.Commands
{
    class CommandCreateStaticPumpEffect : CommandBase
    {
        public readonly Int32 CardID;
        public readonly Int32 Power;
        public readonly Int32 Toughness;

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
