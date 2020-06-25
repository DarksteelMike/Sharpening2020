using System;
namespace Sharpening2020.Commands
{
    public abstract class CommandBase : ICloneable
    {
        public abstract void Do(Game g);
        public abstract void Undo(Game g);
        public abstract object Clone();

        public virtual void UpdateViews(Game g) { }
    }
}
