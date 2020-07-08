using System;

using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandSacrifice : CommandBase
    {
        [ProtoMember(1)]
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
