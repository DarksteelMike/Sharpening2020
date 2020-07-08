using System;
using System.Collections.Generic;

using Sharpening2020.Mana;
using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandClearManaPool : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> PlayerID;

        public CommandClearManaPool(Int32 pid)
        {
            PlayerID = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            prevPool = new List<LazyGameObject<ManaPoint>>();

            Player p = PlayerID.Value(g);

            prevPool.AddRange(p.ManaPool);

            p.ManaPool.Clear();
        }

        private List<LazyGameObject<ManaPoint>> prevPool;

        public override void Undo(Game g)
        {
            Player p = PlayerID.Value(g);
            p.ManaPool.AddRange(prevPool);
        }

        public override object Clone()
        {
            return new CommandClearManaPool(PlayerID.ID);
        }
    }
}
