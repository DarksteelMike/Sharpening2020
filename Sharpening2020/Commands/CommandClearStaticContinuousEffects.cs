﻿using System;
using System.Collections.Generic;

using Sharpening2020.Cards.ContinuousEffects;

namespace Sharpening2020.Commands
{
    class CommandClearStaticContinuousEffects : CommandBase
    {
        public override void Do(Game g)
        {
            prev = new List<ContinuousEffect>();

            prev.AddRange(g.MyContinuousEffects.StaticEffects);

            g.MyContinuousEffects.StaticEffects.Clear();
        }

        List<ContinuousEffect> prev;

        public override void Undo(Game g)
        {
            g.MyContinuousEffects.StaticEffects.AddRange(prev);
        }

        public override object Clone()
        {
            return new CommandClearStaticContinuousEffects();
        }

    }
}
