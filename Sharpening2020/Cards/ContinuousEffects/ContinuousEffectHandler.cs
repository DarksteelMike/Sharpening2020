using System;
using System.Collections.Generic;

namespace Sharpening2020.Cards.ContinuousEffects
{
    public class ContinuousEffectHandler : ICloneable
    {
        public Game MyGame;
        //public Game LookAhead; //Not used
        public readonly Dictionary<LayerName, List<ContinuousEffect>> Layers = new Dictionary<LayerName, List<ContinuousEffect>>();
        public readonly List<ContinuousEffect> StaticEffects = new List<ContinuousEffect>();

        private readonly List<ContinuousEffect> executedEffects = new List<ContinuousEffect>();

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
                Layers[ln].Clear();
            }

            foreach (Card c in MyGame.GetCards())
            {
                foreach (ContinuousEffect ce in c.CurrentCharacteristics.ContinuousEffects)
                {
                    if (ce.Applies(MyGame))
                    {
                        Layers[ce.MyLayer].Add(ce);
                    }
                }
            }
            
            foreach(ContinuousEffect ce in StaticEffects)
            {
                Layers[ce.MyLayer].Add(ce);
            }
        }

        public void SortContinuousEffects()
        {
            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                List<ContinuousEffect> curLayer = Layers[ln];

                //TODO: Figure out how the fuck dependencies would work. Just sort by timestamp for now.

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
            foreach (ContinuousEffect ce in executedEffects)
            {
                ce.Undo(MyGame);
            }
            executedEffects.Clear();

            GatherContinuousEffects();
            SortContinuousEffects();

            foreach (LayerName ln in Enum.GetValues(typeof(LayerName)))
            {
                foreach(ContinuousEffect ce in Layers[ln])
                {
                    executedEffects.Add(ce);
                    ce.Do(MyGame);

                    ce.UpdateViews(MyGame);
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