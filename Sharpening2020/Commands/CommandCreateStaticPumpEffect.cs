using System;

using Sharpening2020.Cards.Static.Presets;

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
            ppt = new PumpPT(CardID, Power, Toughness);

            g.MyContinuousEffects.StaticEffects.Add(ppt);
        }

        private PumpPT ppt;

        public override void Undo(Game g)
        {
            g.MyContinuousEffects.StaticEffects.Remove(ppt);
        }

        public override object Clone()
        {
            return new CommandCreateStaticPumpEffect(CardID, Power, Toughness);
        }
    }
}
