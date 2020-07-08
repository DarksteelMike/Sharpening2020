using System;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandRemoveCounter : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<GameObject> Source;
        [ProtoEnum]
        [ProtoMember(2)]
        public readonly CounterType Type;
        [ProtoMember(3)]
        public readonly Int32 Amount;

        public CommandRemoveCounter(Int32 sid, CounterType ct, Int32 amt)
        {
            Source = new LazyGameObject<GameObject>(sid);
            Type = ct;
            Amount = amt;
        }

        public override void Do(Game g)
        {
            ICanHaveCounters ichc = (ICanHaveCounters)Source.Value(g);
            Counter cnt = ichc.GetAllCounters(g).Where(x => { return x.MyType == Type; }).FirstOrDefault(); //Default is null for reference types
            if(cnt != null)
            {
                removedCounter = new LazyGameObject<Counter>(cnt);
                ichc.RemoveCounter(cnt);
                g.GameObjects.Remove(cnt);
            }
        }

        private LazyGameObject<Counter> removedCounter;

        public override void Undo(Game g)
        {
            if (removedCounter == null)
                return;

            ICanHaveCounters ichc = (ICanHaveCounters)Source.Value(g);
            ichc.AddCounter(removedCounter.Value(g));
            g.GameObjects.Add(removedCounter.Value(g));
        }

        public override object Clone()
        {
            return new CommandRemoveCounter(Source.ID, Type, Amount);
        }

        public override void UpdateViews(Game g)
        {
            GameObject go = g.GetGameObjectByID(Source.ID);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                if(go is Card)
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
