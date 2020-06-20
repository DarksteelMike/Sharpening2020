using System;

using Sharpening2020.Input;
using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Views;

namespace Sharpening2020.Commands
{
    class CommandAddManaToPool : CommandBase
    {
        public readonly Int32 PlayerID;
        public readonly ManaColor Color;

        public CommandAddManaToPool(Int32 pid, ManaColor mc)
        {
            PlayerID = pid;
            Color = mc;
        }

        public override void Do(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            point = new ManaPoint();
            point.MyColor = Color;

            g.RegisterGameObject(point);

            p.ManaPool.Add(point);
        }

        private ManaPoint point;

        public override void Undo(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);
            p.ManaPool.Remove(point);
            g.GameObjects.Remove(point);
            g.NextGameObjectID--;
        }

        public override object Clone()
        {
            return new CommandAddManaToPool(PlayerID, Color);
        }

        public override void UpdateViews(Game g)
        {
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdatePlayerView((PlayerView)((Player)g.GetGameObjectByID(this.PlayerID)).GetView(g));
            }
        }
    }
}
