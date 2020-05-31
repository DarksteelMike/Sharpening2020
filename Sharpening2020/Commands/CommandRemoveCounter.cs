using System;
using System.Linq;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandRemoveCounter : CommandBase
    {
        public readonly Int32 SourceID;
        public readonly CounterType Type;

        public CommandRemoveCounter(Int32 sid, CounterType ct)
        {
            SourceID = sid;
            Type = ct;
        }

        public override void Do(Game g)
        {
            ICanHaveCounters ichc = (ICanHaveCounters)g.GetGameObjectByID(SourceID);
            removedCounter = ichc.GetAllCounters().Where(x => { return x.MyType == Type; }).First();

            ichc.RemoveCounter(removedCounter);
        }

        private Counter removedCounter;

        public override void Undo(Game g)
        {
            ICanHaveCounters ichc = (ICanHaveCounters)g.GetGameObjectByID(SourceID);
            ichc.AddCounter(removedCounter);
        }

        public override object Clone()
        {
            return new CommandRemoveCounter(SourceID, Type);
        }
    }
}
