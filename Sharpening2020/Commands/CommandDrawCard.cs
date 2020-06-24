using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Sharpening2020.Commands
{
    class CommandDrawCard : CommandBase
    {
        public readonly Int32 PlayerID;

        public CommandDrawCard(Int32 pid)
        {
            PlayerID = pid;
        }

        public override void Do(Game g)
        {
            Player p = (Player)g.GetGameObjectByID(PlayerID);

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
            return new CommandDrawCard(PlayerID);
        }
    }
}
