using System;

using Sharpening2020.Cards;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    //For the sake of triggers, this command deals a specific amount of damage to a specific game object in the appropriate way.
    class CommandDealDamage : CommandBase
    {
        [ProtoMember(1)]
        public readonly Int32 TargetID;
        [ProtoMember(2)]
        public readonly Int32 Amount;

        private CommandDealDamage() { }

        public CommandDealDamage(Int32 tid, Int32 amt)
        {
            TargetID = tid;
            Amount = amt;
        }

        public override void Do(Game g)
        {
            GameObject go = g.GetGameObjectByID(TargetID);

            if(go is Card)
            {
                Card c = (Card)go;

                if(c.CurrentCharacteristics.CardTypes.Contains("Planeswalker"))
                {
                    g.MyExecutor.Do(new CommandRemoveCounter(TargetID, CounterType.Loyalty, Amount));
                }
                else if(c.CurrentCharacteristics.CardTypes.Contains("Battle"))
                {
                    g.MyExecutor.Do(new CommandRemoveCounter(TargetID, CounterType.Defense, Amount));
                }
                else
                {
                    g.MyExecutor.Do(new CommandAssignDamage(TargetID, Amount));
                }
            }
            else
            {
                g.MyExecutor.Do(new CommandLoseLife(TargetID, Amount));
            }
        }

        public override void Undo(Game g)
        {
            //No need.
        }

        public override object Clone()
        {
            return new CommandDealDamage(TargetID, Amount);
        }
    }
}
