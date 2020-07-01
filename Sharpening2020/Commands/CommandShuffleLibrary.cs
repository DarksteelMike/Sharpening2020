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
        public readonly LazyGameObject<Player> Player;
        public readonly Int32 Seed;

        public CommandShuffleLibrary(Int32 pid, Int32 sd)
        {
            Player = new LazyGameObject<Player>(pid);
            Seed = sd;
        }

        public override void Do(Game g)
        {
            Zone lib = Player.Value(g).MyZones[ZoneType.Library];
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

        private List<LazyGameObject<Card>> originalOrder;

        public override void Undo(Game g)
        {
            Zone lib = ((Player)g.GetGameObjectByID(Player.ID)).MyZones[ZoneType.Library];
            lib.Contents.Clear();
            foreach(LazyGameObject<Card> lgo in originalOrder)
            {
                lib.Contents.Add(lgo);
            }
        }

        public override object Clone()
        {
            return new CommandShuffleLibrary(Player.ID, Seed);
        }

        public override void UpdateViews(Game g)
        {
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(ZoneType.Library, Player.ID, g.GetCards(ZoneType.Library).Select(x => { return (CardView)x.GetView(g, ih.AssociatedPlayer.Value(g)); }).ToList());
            }
        }
    }
}
