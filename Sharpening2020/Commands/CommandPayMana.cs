using System;

using Sharpening2020.Input;
using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandPayMana : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Payer;
        [ProtoMember(2)]
        public readonly LazyGameObject<ManaPoint> ManaPoint;
        [ProtoMember(3)]
        public readonly Int32 CostIndex;

        private CommandPayMana() { }

        public CommandPayMana(Int32 pid, Int32 mpid, Int32 ci)
        {
            Payer = new LazyGameObject<Player>(pid);
            ManaPoint = new LazyGameObject<ManaPoint>(mpid);
            CostIndex = ci;
        }

        public override void Do(Game g)
        {
            Player p = Payer.Value(g);
            InputHandler IH = g.InputHandlers[Payer.ID];
            PayManaCost pmc = (PayManaCost)IH.CurrentInputState;
            mp = ManaPoint.Value(g);

            pmc.MyActivatable.MyCost.ManaParts[CostIndex].Pay(mp, g);
            pmc.MyActivatable.MyCost.PaidMana.Add(pmc.MyActivatable.MyCost.ManaParts[CostIndex]);
            p.ManaPool.Remove(ManaPoint);
            g.GameObjects.Remove(mp);
        }
        
        private ManaPoint mp;

        public override void Undo(Game g)
        {
            Player p = Payer.Value(g);
            InputHandler IH = g.InputHandlers[Payer.ID];
            PayManaCost pmc = (PayManaCost)IH.CurrentInputState;

            pmc.MyActivatable.MyCost.PaidMana.Remove(pmc.MyActivatable.MyCost.ManaParts[CostIndex]);
            p.ManaPool.Add(new LazyGameObject<ManaPoint>(mp));
            g.GameObjects.Add(mp);
        }

        public override object Clone()
        {
            return new CommandPayMana(Payer.ID, ManaPoint.ID, CostIndex);
        }

        public override void UpdateViews(Game g)
        {
            foreach(InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdatePlayerView((PlayerView)((Player)g.GetGameObjectByID(Payer.ID)).GetView(g, ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
