using System;
using System.Collections.Generic;

using SeventhTask.Logic.Components.Interfaces;

namespace SeventhTask.Logic.Components
{
    internal class NaturalSequence : ISequence
    {
        public const int POW_TO_NATURAL_NUMBER = 2;

        public double MaxRange { get; set; }

        public NaturalSequence(double maxRange) 
        {
            MaxRange = maxRange;
        }

        public IEnumerable<int> GetEnumerator() 
        {
            for (int i = 0; Math.Pow(i, POW_TO_NATURAL_NUMBER) < MaxRange; i++)
            {
                yield return i;
            }
        }
    }
}
