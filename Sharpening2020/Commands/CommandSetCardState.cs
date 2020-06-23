using System;

using Sharpening2020.Cards;

namespace Sharpening2020.Commands
{
    class CommandSetCardState : CommandBase
    {
        public readonly Int32 CardID;
        public readonly CharacteristicName NewState;

        public CommandSetCardState(Int32 cid, CharacteristicName st)
        {
            CardID = cid;
            NewState = st;
        }

        public override void Do(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);

            oldState = c.CurrentCharacteristicName;
            c.CurrentCharacteristicName = NewState;
        }

        private CharacteristicName oldState;

        public override void Undo(Game g)
        {
            Card c = (Card)g.GetGameObjectByID(CardID);
            c.CurrentCharacteristicName = oldState;
        }

        public override object Clone()
        {
            return new CommandSetCardState(CardID, NewState);
        }
    }
}
