using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core.Engine.Strategy
{
    /// <summary>
    /// Computes the next generation of living cells in The Game of Life.
    /// </summary>
    /// 
    /// <remarks>
    /// This approach stores the next generation of cells to output, but otherwise minimizes additional memory usage.
    /// It may repeat work by analyzing the next state of cells that neighbor currently living cells and don't transition to,
    /// or remain in, a living state in the next generation.
    /// 
    /// Even with overlapping work, each living cell has constant (8) number of neighbors, each of which has the same constant
    /// number of neighbors. Overall processing is O(n), where n is number of currently living cells.
    /// </remarks>
    public class ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy : IGenerationStrategy
    {
        private readonly IGameRules gameRules;

        /// <summary>
        /// Construct the strategy with <see cref="GameRules.StandardRulesInstance"/>.
        /// </summary>
        public ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy()
            : this(GameRules.StandardRulesInstance)
        {
        }

        /// <summary>
        /// Construct the strategy with the provided <see cref="IGameRules" />.
        /// </summary>
        /// <param name="gameRules">The <see cref="IGameRules"/> to use.</param>
        public ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy(IGameRules gameRules)
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
            var nextGeneration = new HashSet<Cell>();
            foreach (var cell in liveCells)
            {
                foreach (var neighbor in cell.FindValidNeighbors())
                {
                    if (nextGeneration.Contains(neighbor))
                    {
                        // Previously determined this cell is alive next generation.
                        // No need to do so again.
                        continue;
                    }

                    var aliveSecondaryNeighbors = neighbor
                        .FindValidNeighbors()
                        .Where(secondaryNeighbor => liveCells.Contains(secondaryNeighbor))
                        .ToList();

                    if (this.gameRules.ShouldCellLive(liveCells.Contains(neighbor), aliveSecondaryNeighbors.Count))
                    {
                        nextGeneration.Add(neighbor);
                    }
                }
            }

            return nextGeneration;
        }
    }
}
