using System;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Triggers;
using Sharpening2020.Commands;
using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Cards
{
    public class Soul_Warden : Card
    {
        public override void Build()
        {
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Soul Warden";
            Front.CardTypes.Add("Creature");
            Front.SubTypes.Add("Human");
            Front.SubTypes.Add("Cleric");

            Front.Power = 1;
            Front.Toughness = 1;

            LazyGameObject<Card> lazyThis = new LazyGameObject<Card>(this);

            CastPermanent cast = new CastPermanent(lazyThis);

            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.White));

            Front.Activatables.Add(cast);

            GainLifeDefinedAbility gla = new GainLifeDefinedAbility(lazyThis, this.Controller, 1);

            Func<CommandBase, Game, Boolean> shouldTrigger = (x, g) =>
            {
                if (!(x is CommandMoveCard))
                    return false;

                CommandMoveCard move = (CommandMoveCard)x;

                g.DebugAlert(DebugMode.Triggers, move.ToString(g));

                if (move.Destination != ZoneType.Battlefield)
                {
                    g.DebugAlert(DebugMode.Triggers, "Soul Warden should: failed destination");
                    return false; //It must move to the battlefield.
                }

                if (move.CardID.ID == this.ID)
                {
                    g.DebugAlert(DebugMode.Triggers, "Soul Warden should: failed id");
                    return false; //Must be another card
                }

                if (!move.CardID.Value(g).CurrentCharacteristics.CardTypes.Contains("Creature"))
                {
                    g.DebugAlert(DebugMode.Triggers, "Types:");
                    foreach (String s in move.CardID.Value(g).CurrentCharacteristics.CardTypes)
                    {
                        g.DebugAlert(DebugMode.Triggers, s);
                    }
                    g.DebugAlert(DebugMode.Triggers, "Soul Warden should: failed type");
                    return false; //Must be a creature
                }

                return true;
            };

            Func<Trigger, Game, Boolean> canTrigger = (x, g) =>
            {
                Boolean res = g.GetZoneTypeOf(x.host) == ZoneType.Battlefield;


                if (!res)
                {
                    g.DebugAlert(DebugMode.Triggers, "Soulwarden can: failed zone");
                }

                return res;
            };

            Trigger trig = new Trigger(shouldTrigger, canTrigger, gla, lazyThis);

            Front.Triggers.Add(trig);
        }

        public override object Clone()
        {
            return base.Clone(new Soul_Warden());
        }
    }
}