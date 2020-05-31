using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Cards.Static
{
    public enum LayerName { Layer1A, Layer1B, Layer2, Layer3, Layer4, Layer5, Layer6, Layer7A, Layer7B, Layer7C, Layer7D }
    public abstract class ContinuousEffect : ICloneable,IEquatable<ContinuousEffect>
    {
        public LayerName MyLayer;

        public LazyGameObject<Card> Host;

        public Int32 Timestamp;

        //Currently unused
        public List<ContinuousEffect> DependsOn = new List<ContinuousEffect>();

        public abstract Boolean Applies(Game g);

        public abstract void Do(Game g);

        public abstract void Undo(Game g);

        public abstract Boolean Equals(ContinuousEffect other);

        public abstract object Clone();
    }
}
