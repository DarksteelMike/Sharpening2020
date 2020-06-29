using System;

namespace Sharpening2020.Cards.ContinuousEffects
{
    public enum LayerName { Layer1A, Layer1B, Layer2, Layer3, Layer4, Layer5, Layer6, Layer7A, Layer7B, Layer7C, Layer7D }
    public enum Duration { Permanent, EndOfTurn }
    public abstract class ContinuousEffect : ICloneable
    {
        public LayerName MyLayer;

        public LazyGameObject<Card> Host;

        public Int32 Timestamp;

        public Duration MyDuration = Duration.Permanent;

        //Currently unused
        //public List<ContinuousEffect> DependsOn = new List<ContinuousEffect>();

        public abstract Boolean Applies(Game g);

        public abstract void Do(Game g);

        public abstract void Undo(Game g);

        public abstract void UpdateViews(Game g);

        public abstract object Clone();
    }
}
