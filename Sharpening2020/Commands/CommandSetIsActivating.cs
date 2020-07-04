using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;

namespace Sharpening2020.Commands
{
    class CommandSetIsActivating : CommandBase
    {
        public readonly LazyGameObject<Card> Card;
        public readonly Int32 ActivatableIndex;
        public readonly Boolean Mode;
        public readonly AbilityType AbilityType;

        public CommandSetIsActivating(Int32 cid, Int32 aind, Boolean m, AbilityType abt)
        {
            Card = new LazyGameObject<Card>(cid);
            ActivatableIndex = aind;
            Mode = m;
            AbilityType = abt;
        }

        public override void Do(Game g)
        {
            if(AbilityType == AbilityType.Activatable)
            {
                prev = Card.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex].IsBeingActivated;
                Card.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex].IsBeingActivated = Mode;
            }
            else if(AbilityType == AbilityType.Trigger)
            {
                prev = Card.Value(g).CurrentCharacteristics.Triggers[ActivatableIndex].myAbility.IsBeingActivated;
                Card.Value(g).CurrentCharacteristics.Triggers[ActivatableIndex].myAbility.IsBeingActivated = Mode;
            }
        }

        private Boolean prev = true;

        public override void Undo(Game g)
        {
            if (AbilityType == AbilityType.Activatable)
            {
                Card.Value(g).CurrentCharacteristics.Activatables[ActivatableIndex].IsBeingActivated = prev;
            }
            else if (AbilityType == AbilityType.Trigger)
            {
                Card.Value(g).CurrentCharacteristics.Triggers[ActivatableIndex].myAbility.IsBeingActivated = prev;
            }
            
        }

        public override object Clone()
        {
            return new CommandSetIsActivating(Card.ID, ActivatableIndex, Mode, AbilityType);
        }
    }
}
