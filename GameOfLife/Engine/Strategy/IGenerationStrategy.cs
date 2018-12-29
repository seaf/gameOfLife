using System.Collections.Generic;

namespace GameOfLife.Engine.Strategy
{
    /// <summary>
    /// Abstraction of the logic for moving the game forward by computing the game's next state.
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
 