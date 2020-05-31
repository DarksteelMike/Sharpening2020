using System;
using System.Collections;
using System.Collections.Generic;
using Sharpening2020.Cards;

namespace Sharpening2020
{
    interface ICanHaveCounters
    {
        Int32 GetCounterAmount(CounterType ct);
        void RemoveCounter(Counter c);
        void RemoveCounterType(CounterType ct);
        void AddCounter(Counter c);
        IEnumerable<Counter> GetAllCounters();
    }
}
