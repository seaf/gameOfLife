using System;
using System.Collections.Generic;

namespace GameOfLife.Engine.Strategy
{
    public interface IGenerationStrategy
    {
        HashSet<Tuple<ulong, ulong>> AdvanceGeneration(HashSet<Tuple<ulong, ulong>> liveCells);
    }
}
