using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpening2020.Cards.Static
{
    public class ContinuousEffectHandler : ICloneable
    {
        public Game MyGame;
        public Game LookAhead; //Not used
        public Dictionary<LayerName, List<ContinuousEffect>> Layers = new Dictionary<LayerName, List<ContinuousEffect>>();

        public ContinuousEffectHandler()
        {
            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                Layers.Add(ln, new List<ContinuousEffect>());
            }
        }

        public void UpdateGameReference(Game NewReference)
        {
            MyGame = NewReference;
        }

        public void GatherContinuousEffects()
        {
            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                foreach(ContinuousEffect ce in Layers[ln])
                {
                    ce.Undo(MyGame);
                }
            }
            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                Layers[ln].Clear();
            }

            foreach (GameObject go in MyGame.GetCards())
            {
                Card c = (Card)go;
                foreach (ContinuousEffect ce in c.CurrentCharacteristics.ContinuousEffects)
                {
                    if (ce.Applies(MyGame))
                    {
                        Layers[ce.MyLayer].Add(ce);
                    }
                }
            }            
        }

        public void SortContinuousEffects()
        {
            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                List<ContinuousEffect> curLayer = Layers[ln];

                //Establish Dependencies
                LookAhead = (Game)MyGame.Clone();
                //TODO: Figure out how the fuck this would work. Just sort by timestamp for now.

                curLayer.Sort((ContinuousEffect one, ContinuousEffect other) =>
                    {
                        if (one.Timestamp < other.Timestamp)
                        {
                            return 1;
                        }
                        if (one.Timestamp == other.Timestamp)
                        {
                            return 0;
                        }

                        return -1;
                    });

                
            }
        }

        public void RunContinuousEffects()
        {
            GatherContinuousEffects();
            SortContinuousEffects();

            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                foreach(ContinuousEffect ce in Layers[ln])
                {
                    ce.Do(MyGame);
                }
            }
        }

        public object Clone()
        {
            ContinuousEffectHandler ret = new ContinuousEffectHandler();
            foreach(LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                foreach(ContinuousEffect ce in Layers[ln])
                {
                    ret.Layers[ln].Add(ce);
                }
            }

            return ret;
        }
    }
}