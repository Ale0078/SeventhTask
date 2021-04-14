using System;
using System.Collections.Generic;

using static System.Console;

NaturalNumber number = new(12);

foreach (int num in number) 
{
    Write($"{num}, ");
}

ReadKey();

class NaturalNumber
{
    public const int POW = 2;

    public double NumberToGetSequence { get; set; }

    public NaturalNumber(double numberToGetSequence) 
    {
        NumberToGetSequence = numberToGetSequence;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; Math.Pow(i, POW) < NumberToGetSequence; i++)
        {
            yield return i;
        }
    }
}