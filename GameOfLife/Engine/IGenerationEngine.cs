using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    public interface IGenerationEngine
    {
        /// <summary>
        /// Given a set of live cells, create the next generation of live cells.
        /// </summary>
        /// <param name="liveCells">Current generation of living cells</param>
        /// <returns>New generation of live cells</returns>
        HashSet<Tuple<ulong, ulong>> Advance(HashSet<Tuple<ulong, ulong>> liveCells);
    }
}
