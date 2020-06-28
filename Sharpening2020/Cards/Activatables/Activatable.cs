using System;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts;
using Sharpening2020.Cards.Targets;
using Sharpening2020.Players;

namespace Sharpening2020.Cards.Activatables
{
    public abstract class Activatable : ICloneable
    {
        public LazyGameObject<Card> Host;

        public Player Activator;

        public Boolean IsBeingActivated = false;

        public Cost MyCost = new Cost();

        public Targeting MyTargeting = new Targeting();

        public virtual Boolean CanActivate(Player act, Game g)
        {
            foreach(ActionCostPart acp in MyCost.ActionParts)
            {
                if(!acp.CanBeDone(g))
                {
                    return false;
                }
            }

            return true;
        }
        public abstract void Resolve(Game g, StackInstance si);

        public abstract object Clone();

        public abstract String ToString(Game g);
    }
}
