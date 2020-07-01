using System;

using Sharpening2020.Input;
using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Views;

namespace Sharpening2020.Commands
{
    class CommandAddManaToPool : CommandBase
    {
        public readonly LazyGameObject<Player> Player;
        public readonly ManaColor Color;

        public CommandAddManaToPool(Int32 pid, ManaColor mc)
        {
            Player = new LazyGameObject<Player>(pid);
            Color = mc;
        }

        public override void Do(Game g)
        {
            Player p = Player.Value(g);
            point = new ManaPoint();
            point.MyColor = Color;

            g.RegisterGameObject(point);

            p.ManaPool.Add(new LazyGameObject<ManaPoint>(point));
        }

        private ManaPoint point;

        public override void Undo(Game g)
        {
            Player p = Player.Value(g);
            p.ManaPool.RemoveAll(x => { return x.ID == point.ID; });
            g.GameObjects.Remove(point);
            g.NextGameObjectID--;
        }

        public override object Clone()
        {
            return new CommandAddManaToPool(Player.ID, Color);
        }

        public override void UpdateViews(Game g)
        {
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdatePlayerView((PlayerView)Player.Value(g).GetView(g, ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
