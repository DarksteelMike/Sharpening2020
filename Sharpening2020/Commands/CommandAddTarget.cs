using System;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Input;

namespace Sharpening2020.Commands
{
    class CommandAddTarget : CommandBase
    {
        public readonly LazyGameObject<Card> Card;
        public readonly Int32 ActivatableIndex;
        public readonly LazyGameObject<GameObject> Target;

        public CommandAddTarget(Int32 tid, Int32 aind, Int32 oid)
        {
            Card = new LazyGameObject<Card>(tid);
            ActivatableIndex = aind;
            Target = new LazyGameObject<GameObject>(oid);
        }

        public override void Do(Game g)
        {
            Card c = Card.Value(g);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            go = Target.Value(g);

            act.MyTargeting.Targeted.Add(go);
        }
        
        private GameObject go;

        public override void Undo(Game g)
        {
            Card c = Card.Value(g);
            Activatable act = c.CurrentCharacteristics.Activatables[ActivatableIndex];

            act.MyTargeting.Targeted.RemoveAt(act.MyTargeting.Targeted.Count - 1);
        }

        public override object Clone()
        {
            return new CommandAddTarget(Card.ID, ActivatableIndex, Target.ID);
        }
    }
}
