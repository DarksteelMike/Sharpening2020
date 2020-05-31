using System;
using System.Linq;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandRemoveCounter : ICommand
    {
        public readonly Int32 SourceID;
        public readonly CounterType Type;

        public CommandRemoveCounter(ICanHaveCounters ichc, CounterType ct)
        {
            SourceID = ((GameObject)ichc).ID;
            Type = ct;
        }

        public void Do(Game g)
        {
            ICanHaveCounters ichc = (ICanHaveCounters)g.GetGameObjectByID(SourceID);
            removedCounter = ichc.GetAllCounters().Where(x => { return x.MyType == Type; }).First();

            ichc.RemoveCounter(removedCounter);
        }

        private Counter removedCounter;

        public void Undo(Game g)
        {

        }
    }
}
