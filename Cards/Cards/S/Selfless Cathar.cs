using System;
using System.Collections.Generic;

using Sharpening2020;
using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.Activatables.Presets;
using Sharpening2020.Cards.ContinuousEffects;
using Sharpening2020.Cards.ContinuousEffects.Presets;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts.Presets;
using Sharpening2020.Commands;
using Sharpening2020.Mana;
using Sharpening2020.Players;
using Sharpening2020.Zones;

namespace Cards
{
    class Selfless_Cathar : Card
    {
        public class PumpAllControlledByMe : ContinuousEffect
        {
            public PumpAllControlledByMe(LazyGameObject<Card> h)
            {
                Host = h;
            }
            public override bool Applies(Game g)
            {
                return true;
            }

            public override void Do(Game g)
            {
                executedCommands.Clear();
                foreach (LazyGameObject<Card> c in Host.Value(g).Controller.Value(g).MyZones[ZoneType.Battlefield].Contents)
                {
                    executedCommands.Add(new CommandAddPowerToughness(c.ID, 1, 1));
                }

                foreach (CommandBase cb in executedCommands)
                    cb.Do(g);
            }

            private List<CommandBase> executedCommands = new List<CommandBase>();

            public override void Undo(Game g)
            {
                foreach (CommandBase cb in executedCommands)
                    cb.Undo(g);
            }

            public override void UpdateViews(Game g)
            {
                foreach (CommandBase cb in executedCommands)
                    cb.UpdateViews(g);
            }

            public override object Clone()
            {
                return new PumpAllControlledByMe(Host);
            }
        }

        public class PumpAllUntilEOF : Ability
        {
            public PumpAllUntilEOF(Card h)
            {
                Host = new LazyGameObject<Card>(h);
            }

            public PumpAllUntilEOF(PumpAllUntilEOF other)
            {

            }

            public override bool CanActivate(Player act, Game g)
            {
                Boolean res = true;

                res &= !IsBeingActivated;
                res &= act.ID == Host.Value(g).Controller.ID;
                res &= g.GetZoneTypeOf(Host) == ZoneType.Battlefield;

                res &= base.CanActivate(act, g);

                return res;
            }

            public override void Resolve(Game g, StackInstance si)
            {
                g.MyExecutor.Do(new CommandCreatePumpAllEffect(Host.ID));
            }

            public override string ToString(Game g)
            {
                return "";
            }

            public override object Clone()
            {
                return new PumpAllUntilEOF(this);
            }
        }

        public class CommandCreatePumpAllEffect : CommandBase
        {
            public readonly Int32 SourceID;

            public CommandCreatePumpAllEffect(Int32 sid)
            {
                SourceID = sid;
            }

            public override void Do(Game g)
            {
                PumpAllControlledByMe pacbm = new PumpAllControlledByMe(new LazyGameObject<Card>(SourceID));
                g.MyContinuousEffects.StaticEffects.Add(pacbm);
            }

            public override void Undo(Game g)
            {
                g.MyContinuousEffects.StaticEffects.RemoveAt(g.MyContinuousEffects.StaticEffects.Count - 1);
            }

            public override object Clone()
            {
                return new CommandCreatePumpAllEffect(SourceID);
            }
        }

        public override void Build()
        {
            Card.AddUniversalCharacteristics(this);
            CardCharacteristics Front = MyCharacteristics[CharacteristicName.Front];

            Front.Name = "Selfless Cathar";
            Front.CardTypes.Add("Creature");
            Front.SubTypes.Add("Human");

            Front.Power = 1;
            Front.Toughness = 1;

            LazyGameObject<Card> lazy = new LazyGameObject<Card>(this);

            CastPermanent cast = new CastPermanent(lazy);

            cast.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.White));

            Front.Activatables.Add(cast);

            PumpAllUntilEOF paue = new PumpAllUntilEOF(this);

            paue.MyCost.ActionParts.Add(new SacSelf(new LazyGameObject<Card>(this)));
            paue.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.Colorless));
            paue.MyCost.ManaParts.Add(new ManaCostPart(ManaColor.White));

            Front.Activatables.Add(paue);
        }

        public override object Clone()
        {
            return base.Clone(new Selfless_Cathar());
        }
    }
}
