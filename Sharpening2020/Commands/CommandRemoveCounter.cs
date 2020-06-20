using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

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
            removedCounter = ichc.GetAllCounters(g).Where(x => { return x.MyType == Type; }).FirstOrDefault(); //Default is null for reference types
            if(removedCounter != null)
            {
                ichc.RemoveCounter(removedCounter);
            }
        }

        private Counter removedCounter;

        public override void Undo(Game g)
        {
            if (removedCounter == null)
                return;

            ICanHaveCounters ichc = (ICanHaveCounters)g.GetGameObjectByID(SourceID);
            ichc.AddCounter(removedCounter);
        }

        public override object Clone()
        {
            return new CommandRemoveCounter(SourceID, Type);
        }

        public override void UpdateViews(Game g)
        {
            GameObject go = g.GetGameObjectByID(SourceID);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                if(go is Card)
                {
                    ih.Bridge.UpdateCardView((CardView)go.GetView(g));
                }
                else
                {
                    ih.Bridge.UpdatePlayerView((PlayerView)go.GetView(g));
                }
            }
        }
    }
}
