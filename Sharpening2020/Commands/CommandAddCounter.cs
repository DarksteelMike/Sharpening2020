using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

namespace Sharpening2020.Commands
{
    class CommandAddCounter : CommandBase
    {
        public readonly Int32 TargetID;
        public readonly CounterType Type;

        public CommandAddCounter(Int32 tid, CounterType ct)
        {
            TargetID = tid;
            Type = ct;
        }

        public override void Do(Game g)
        {
            ICanHaveCounters ichc = (ICanHaveCounters)g.GetGameObjectByID(TargetID);

            addedCounter = new Counter(Type);

            g.RegisterGameObject(addedCounter);

            ichc.AddCounter(addedCounter);
        }

        private Counter addedCounter;

        public override void Undo(Game g)
        {
            ICanHaveCounters ichc = (ICanHaveCounters)g.GetGameObjectByID(TargetID);
            ichc.RemoveCounter(addedCounter);
            g.GameObjects.Remove(addedCounter);
        }

        public override object Clone()
        {
            return new CommandAddCounter(TargetID, Type);
        }

        public override void UpdateViews(Game g)
        {
            GameObject go = g.GetGameObjectByID(TargetID);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                if (go is Card)
                {
                    ih.Bridge.UpdateCardView((CardView)go.GetView(g, ih.AssociatedPlayer.Value(g)));
                }
                else
                {
                    ih.Bridge.UpdatePlayerView((PlayerView)go.GetView(g, ih.AssociatedPlayer.Value(g)));
                }
            }
        }
    }
}
