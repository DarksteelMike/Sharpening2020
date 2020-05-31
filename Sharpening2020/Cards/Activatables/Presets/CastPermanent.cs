using System;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Commands;
using Sharpening2020.Players;

namespace Sharpening2020.Cards.Activatables.Presets
{
    public class CastPermanent : Spell,ICloneable
    {
        public CastPermanent() { }
        public CastPermanent(LazyGameObject<Card> h)
        {
            Host = h;
        }

        public override Boolean CanActivate(Player p, Game g)
        {
            return false;
        }

        public override void Resolve(Game g)
        {
            ZoneType curZ = Host.Value(g).MyZone;

            CommandBase com = new CommandMoveCard(Host.Value(g).ID, curZ, ZoneType.Battlefield);

            g.MyExecutor.Do(com);
        }

        public override object Clone()
        {
            CastPermanent ret = new CastPermanent();
            ret.MyCost = (Cost)this.MyCost.Clone();

            return ret;
        }

        public override string ToString(Game g)
        {
            return "Cast " + Host.Value(g).CurrentCharacteristics.Name + " for " + MyCost.ToString();
        }
    }
}
