using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandAssignDamage : CommandBase
    {
        public readonly LazyGameObject<Card> Target;
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
