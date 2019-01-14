using System;
using System.Collections.Generic;

namespace GameOfLife.Core.Engine.Strategy
{
    /// <summary>
    /// Computes the next generation of alive cells in the Game of Life.
    /// </summary>
    /// 
    /// <remarks>
    /// Creates a mapping of cells that have a non-zero number of adjacent alive cells to the number 
    /// of alive adjacent cells they have. Once counts are complete, walk the entries in the collection
    /// and determine the future state of each.
    /// 
    /// This approach uses a linear [O(n), where n is the number of living cells in the current generation]
    /// amount of additional memory. This may be problematic for game states with a large number of living cells.
    /// 
    /// Computation is also linear in n. For each live cell, we may add up to nine neighboring cells with counts to the mapping.
    /// In the worst case, this mapping will contain 9n entries which is still O(n) to walk.
    /// </remarks>
    internal class StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy : IGenerationStrategy
    {
        private readonly IGameRules gameRules;

        /// <summary>
        /// Construct the strategy with <see cref="GameRules.StandardRulesInstance"/>.
        /// </summary>
        public StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy()
            : this(GameRules.StandardRulesInstance)
        {
        }

        /// <summary>
        /// Construct the strategy with the provided <see cref="IGameRules" />.
        /// </summary>
        /// <param name="gameRules">The <see cref="IGameRules"/> to use.</param>
        public StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy(IGameRules gameRules)
        {
            this.gameRules = gameRules ?? throw new ArgumentNullException(nameof(gameRules));
        }

        /// <summary>
        /// Computes the next generation of the game's state.
        /// </summary>
        /// <param name="liveCells">The set of currently living cells.</param>
        /// <returns>The set of living cells in the next generation.</returns>
        public HashSet<Cell> AdvanceGeneration(HashSet<Cell> liveCells)
        {
            var newGeneration = new HashSet<Cell>();
            var cellsWithNonZeroLivingNeighbors = new Dictionary<Cell, byte>();
            foreach (var cell in liveCells)
            {
                foreach (var neighbor in cell.FindValidNeighbors())
                {
                    if (!cellsWithNonZeroLivingNeighbors.TryGetValue(neighbor, out byte count))
                    {
                        cellsWithNonZeroLivingNeighbors[neighbor] = 1;
                    }
                    else
                    {
                        cellsWithNonZeroLivingNeighbors[neighbor]++;
                    }
                }
            }

            foreach (var candidateCellAndAliveNeighborCount in cellsWithNonZeroLivingNeighbors)
            {
                if (this.gameRules.ShouldCellLive(
                    liveCells.Contains(candidateCellAndAliveNeighborCount.Key),
                    candidateCellAndAliveNeighborCount.Value))
                {
                    newGeneration.Add(candidateCellAndAliveNeighborCount.Key);
                }
            }

            return newGeneration;
        }
    }
}
