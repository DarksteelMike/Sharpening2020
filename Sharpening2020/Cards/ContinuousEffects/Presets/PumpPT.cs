using System;

using Sharpening2020.Commands;
using Sharpening2020.Zones;

namespace Sharpening2020.Cards.ContinuousEffects.Presets
{
    class PumpPT : ContinuousEffect
    {
        public readonly LazyGameObject<Card> Target;
        public readonly CommandAddPowerToughness MyCommand;

        public PumpPT(Int32 CardID,Int32 Power, Int32 Toughness, Int32 TimeStamp)
        {
            Target = new LazyGameObject<Card>(CardID);
            MyCommand = new CommandAddPowerToughness(CardID, Power, Toughness);
            MyDuration = Duration.EndOfTurn;
            MyLayer = LayerName.Layer7C;
            Timestamp = TimeStamp;
        }

        //Copy Constructor
        public PumpPT(PumpPT other)
        {
            Target = (LazyGameObject<Card>)other.Target.Clone();
            MyCommand = (CommandAddPowerToughness)other.MyCommand.Clone();
            MyDuration = Duration.EndOfTurn;
            MyLayer = LayerName.Layer7C;
            Timestamp = other.Timestamp;
        }

        public override bool Applies(Game g)
        {
            return g.GetZoneTypeOf(Target) == ZoneType.Battlefield;
        }

        public override void Do(Game g)
        {
            MyCommand.Do(g);

            //This can somehow hopefully be improved.
            MyCommand.UpdateViews(g);
        }

        public override void Undo(Game g)
        {
            MyCommand.Undo(g);
        }

        public override object Clone()
        {
            return new PumpPT(this);
        }
    }
}
