using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    class GenerationEngine : IGenerationEngine
    {
        public HashSet<Tuple<ulong, ulong>> Advance(HashSet<Tuple<ulong, ulong>> liveCells)
        {
            // TODO
            return liveCells;
        }
    }
}
