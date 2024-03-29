﻿using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Players;
using Sharpening2020.Views;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //This command shuffles the library of a specific player with a specific random seed.
    class CommandShuffleLibrary : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;
        [ProtoMember(2)]
        public readonly Int32 Seed;

        private CommandShuffleLibrary() { }

        public CommandShuffleLibrary(Int32 pid, Int32 sd)
        {
            Player = new LazyGameObject<Player>(pid);
            Seed = sd;
        }

        public override void Do(Game g)
        {
            Zone lib = Player.Value(g).MyZones[ZoneType.Library];
            originalOrder = new List<LazyGameObject<Card>>(lib.Contents);

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
