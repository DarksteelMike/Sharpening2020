using System;

using Sharpening2020.Cards;
using Sharpening2020.Players;
using Sharpening2020.Zones;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    class CommandCreateCard : CommandBase
    {
        [ProtoMember(1)]
        public String CardName;
        [ProtoMember(2)]
        public Int32 PlayerID;

        private CommandCreateCard() { }

        public CommandCreateCard(String n, Int32 o)
        {
            CardName = n;
            PlayerID = o;
        }

        public override void Do(Game g)
        {
            c = CardCompiler.Compile(CardName);

            g.RegisterGameObject(c);

            c.Owner = new LazyGameObject<Player>(PlayerID);

            c.Build();

            c.Owner.Value(g).MyZones[ZoneType.Library].Contents.Add(new LazyGameObject<Card>(c));
            c.CurrentCharacteristicName = CharacteristicName.FaceDown;
        }

        Card c;

        public override void Undo(Game g)
        {
            g.GameObjects.Remove(c);
            c.Owner.Value(g).MyZones[ZoneType.Library].Contents.RemoveAll(x => { return x.ID == c.ID; });
        }

        public override object Clone()
        {
            return new CommandCreateCard(CardName, PlayerID);
        }
    }
}
