using System;

using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.Views;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    public class CommandAddPowerToughness : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Card> CardID;
        [ProtoMember(2)]
        public readonly Int32 Power;
        [ProtoMember(3)]
        public readonly Int32 Toughness;

        public CommandAddPowerToughness(Int32 cid, Int32 p, Int32 t)
        {
            CardID = new LazyGameObject<Card>(cid);
            Power = p;
            Toughness = t;
        }

        public override void Do(Game g)
        {
            Card c = CardID.Value(g);

            c.CurrentCharacteristics.Power += Power;
            c.CurrentCharacteristics.Toughness += Toughness;
        }

        public override void Undo(Game g)
        {
            Card c = CardID.Value(g);

            c.CurrentCharacteristics.Power -= Power;
            c.CurrentCharacteristics.Toughness -= Toughness;
        }

        public override object Clone()
        {
            return new CommandAddPowerToughness(CardID.ID, Power, Toughness);
        }

        public override void UpdateViews(Game g)
        {
            Card c = CardID.Value(g);
            foreach (InputHandler ih in g.InputHandlers.Values)
            {
                ih.Bridge.UpdateCardView((CardView)c.GetView(g,ih.AssociatedPlayer.Value(g)));
            }
        }
    }
}
