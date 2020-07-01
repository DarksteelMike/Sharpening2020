using System;

using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    class CommandIncreaseCardsDrawn : CommandBase
    {
        public readonly LazyGameObject<Player> Player;

        public CommandIncreaseCardsDrawn(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            Player p = Player.Value(g);
            p.CardsDrawnThisTurn++;
        }

        public override void Undo(Game g)
        {
            Player p = Player.Value(g);
            p.CardsDrawnThisTurn--;
        }

        public override object Clone()
        {
            return new CommandIncreaseCardsDrawn(Player.ID);
        }
    }
}
