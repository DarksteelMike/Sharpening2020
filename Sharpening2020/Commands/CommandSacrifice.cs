using System;

using Sharpening2020.Zones;

namespace Sharpening2020.Commands
{
    class CommandSacrifice : CommandBase
    {
        public readonly Int32 CardID;

        public CommandSacrifice(Int32 cid)
        {
            CardID = cid;
        }

        public override void Do(Game g)
        {
            g.MyExecutor.Do(new CommandMoveCard(CardID, ZoneType.Graveyard));
        }

        public override void Undo(Game g)
        {

        }

        public override object Clone()
        {
            return new CommandSacrifice(CardID);
        }
    }
}
