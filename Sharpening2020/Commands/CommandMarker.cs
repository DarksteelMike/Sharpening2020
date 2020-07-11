using System;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    public enum CommandMarkerType { StartActivating, GetPriority }
    [ProtoContract]
    class CommandMarker : CommandBase
    {
        [ProtoEnum]
        [ProtoMember(1)]
        public readonly CommandMarkerType MyType;

        private CommandMarker() { }

        public CommandMarker(CommandMarkerType type)
        {
            MyType = type;
        }

        public override void Do(Game g)
        {
        }

        public override void Undo(Game g)
        {
        }

        public override object Clone()
        {
            return new CommandMarker(MyType);
        }
    }
}
