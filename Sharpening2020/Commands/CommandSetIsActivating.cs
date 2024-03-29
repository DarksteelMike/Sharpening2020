﻿using System;

using Sharpening2020.Attributes;
using Sharpening2020.Cards;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    //This command sets a specific card's specific activatable's state of being activated to true or false.
    class CommandSetIsActivating : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> Card;
        [ProtoMember(2)]
        public readonly Int32 ActivatableIndex;
        [ProtoMember(3)]
        public readonly Boolean Mode;
        [ProtoEnum]
        [ProtoMember(4)]
        public readonly AbilityType AbilityType;

        private CommandSetIsActivating() { }

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
