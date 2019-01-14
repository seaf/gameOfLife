using System.Collections.Generic;

namespace GameOfLife.Core.Engine.Strategy
{
    /// <summary>
    /// Provides methods for interacting with the core logic for the Game of Life.
    /// </summary>
    public interface IGenerationStrategy
    {
        /// <summary>
        /// Computes the next generation of the game's state.
        /// </summary>
        /// <param name="liveCells">The set of currently living cells.</param>
        /// <returns>The set of living cells in the next generation.</returns>
        HashSet<Cell> AdvanceGeneration(HashSet<Cell> liveCells);
    }
}
 