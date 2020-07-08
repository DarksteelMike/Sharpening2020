using System;

using ProtoBuf;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandAssignDamage : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Target;
        [ProtoMember(2)]
        public readonly Int32 Amount;

        public CommandAssignDamage(Int32 tgt,Int32 amt)
        {
            Target = new LazyGameObject<Card>(tgt);
            Amount = amt;
        }

        public override void Do(Game g)
        {
            Target.Value(g).AssignedDamage += Amount;
        }

        public override void Undo(Game g)
        {
            Target.Value(g).AssignedDamage -= Amount;
        }

        public override object Clone()
        {
            return new CommandAssignDamage(Target.ID, Amount);
        }
    }
}
