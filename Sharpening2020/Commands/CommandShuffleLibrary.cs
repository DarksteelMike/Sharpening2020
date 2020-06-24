using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020.Commands
{
    class CommandShuffleLibrary : CommandBase
    {
        public readonly Int32 PlayerID;
        public readonly Int32 Seed;

        public CommandShuffleLibrary(Int32 pid, Int32 sd)
        {
            PlayerID = pid;
            Seed = sd;
        }

        public override void Do(Game g)
        {
            lib = ((Player)g.GetGameObjectByID(PlayerID)).MyZones[ZoneType.Library];
            originalOrder = new List<LazyGameObject<Card>>();
            foreach (LazyGameObject<Card> lgo in lib.Contents)
            {
                originalOrder.Add(lgo);
            }

            Random rng = new Random(Seed);

            int n = lib.Contents.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                LazyGameObject<Card> value = lib.Contents[k];
                lib.Contents[k] = lib.Contents[n];
                lib.Contents[n] = value;
            }
        }

        private Zone lib;
        private List<LazyGameObject<Card>> originalOrder;

        public override void Undo(Game g)
        {
            lib.Contents.Clear();
            foreach(LazyGameObject<Card> lgo in originalOrder)
            {
                lib.Contents.Add(lgo);
            }
        }

        public override object Clone()
        {
            return new CommandShuffleLibrary(PlayerID, Seed);
        }

        public override void UpdateViews(Game g)
        {
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(ZoneType.Library, PlayerID, g.GetCards(ZoneType.Library).Select(x => { return (CardView)x.GetView(g, ih.AssociatedPlayer.Value(g)); }).ToList());
            }
        }
    }
}
