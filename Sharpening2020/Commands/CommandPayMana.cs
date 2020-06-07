using System;

using Sharpening2020.Input;
using Sharpening2020.Mana;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandPayMana : CommandBase
    {
        public readonly Int32 PayerID;
        public readonly Int32 ManaPointID;
        public readonly Int32 CostIndex;

        public CommandPayMana(Int32 pid, Int32 mpid, Int32 ci)
        {
            PayerID = pid;
            ManaPointID = mpid;
            CostIndex = ci;
        }

        public override void Do(Game g)
        {
            p = (Player)g.GetGameObjectByID(PayerID);
            InputHandler IH = g.InputHandlers[PayerID];
            PayManaCost pmc = (PayManaCost)IH.CurrentInputState;
            mp = (ManaPoint)g.GetGameObjectByID(ManaPointID);

            pmc.MyCost.ManaParts[CostIndex].Pay(mp, g);
            pmc.MyCost.PaidMana.Add(pmc.MyCost.ManaParts[CostIndex]);
            p.ManaPool.Remove(mp);
            g.GameObjects.Remove(mp);
        }

        private Player p;
        private ManaPoint mp;

        public override void Undo(Game g)
        {
            InputHandler IH = g.InputHandlers[PayerID];
            PayManaCost pmc = (PayManaCost)IH.CurrentInputState;
            ManaPoint mp = (ManaPoint)g.GetGameObjectByID(ManaPointID);

            pmc.MyCost.PaidMana.Remove(pmc.MyCost.ManaParts[CostIndex]);
            p.ManaPool.Add(mp);
            g.GameObjects.Add(mp);
        }

        public override object Clone()
        {
            return new CommandPayMana(PayerID, ManaPointID, CostIndex);
        }
    }
}
