using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Commands
{
    class CommandDrawCard : CommandBase
    {
        public readonly LazyGameObject<Player> Player;

        public CommandDrawCard(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            Player p = Player.Value(g);

            if (p.MyZones[ZoneType.Library].Contents.Count == 0)
                return; //TEMPORARY

            LazyGameObject<Card> TopCard = p.MyZones[ZoneType.Library].Contents[0];

            g.MyExecutor.Do(new CommandSetCardState(TopCard.ID, CharacteristicName.Front));
            g.MyExecutor.Do(new CommandMoveCard(TopCard.ID, ZoneType.Hand));
            g.MyExecutor.Do(new CommandIncreaseCardsDrawn(p.ID));
        }

        public override void Undo(Game g)
        {
            //Commands performed will be undone on their own.
        }

        public override object Clone()
        {
            return new CommandDrawCard(Player.ID);
        }
    }
}
