using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Mana;
using Sharpening2020.Players;

namespace Sharpening2020.Commands
{
    public abstract class CommandBase : ICloneable
    {
        public abstract void Do(Game g);
        public abstract void Undo(Game g);
        public abstract object Clone();

        public virtual void UpdateViews(Game g) { }

        public String ToString(Game g)
        {
            String res = GetType().Name;
            IEnumerable<FieldInfo> parameters = GetType().GetFields().Where(x => { return x.IsInitOnly; });
            foreach (FieldInfo fi in parameters)
            {
                var ResultingValue = fi.GetValue(this);                    

                GameObject go = null;
                if(ResultingValue.GetType().Name.Equals(typeof(LazyGameObject<>).Name)) 
                {
                    if(ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(Card)))
                    {
                        go = ((LazyGameObject<Card>)ResultingValue).Value(g) as Card;
                    }
                    else if(ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(Player)))
                    {
                        go = ((LazyGameObject<Player>)ResultingValue).Value(g) as Player;
                    }
                    else if (ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(Counter)))
                    {
                        go = ((LazyGameObject<Counter>)ResultingValue).Value(g) as Counter;
                    }
                    else if (ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(StackInstance)))
                    {
                        go = ((LazyGameObject<StackInstance>)ResultingValue).Value(g) as StackInstance;
                    }
                    else if (ResultingValue.GetType().GenericTypeArguments[0].Equals(typeof(ManaPoint)))
                    {
                        go = ((LazyGameObject<ManaPoint>)ResultingValue).Value(g) as ManaPoint;
                    }
                }
                if(go != null)
                {
                    res += "(" + fi.Name + ":" + go.ToString(g) + ")";
                }
                else
                {
                    res += "(" + fi.Name + ":" + ResultingValue.ToString() + ")";
                }
            }

            return res;
        }
    }
}
