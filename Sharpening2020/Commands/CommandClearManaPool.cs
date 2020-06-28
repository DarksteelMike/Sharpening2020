using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharpening2020.Mana;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandClearManaPool : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandClearManaPool(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            prevPool = new List<LazyGameObject<ManaPoint>>();

            Player p = (Player)g.GetGameObjectByID(PlayerID);

            prevPool.AddRange(p.ManaPool);

            p.ManaPool.Clear();
        }

        private List<LazyGameObject<ManaPoint>> prevPool;

        public override void Undo(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            p.ManaPool.AddRange(prevPool);
        }

        public override object Clone()
        {
            return new CommandClearManaPool(PlayerID);
        }
    }
}
