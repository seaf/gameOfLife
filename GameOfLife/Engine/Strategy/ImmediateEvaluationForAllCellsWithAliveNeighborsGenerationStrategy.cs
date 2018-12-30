using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Engine.Strategy
{
    /// <summary>
    /// Computes the next generation of living cells in The Game of Life.
    /// 
    /// This approach stores the next generation of cells to output, but otherwise minimizes additional memory usage.
    /// Instead, it may repeat work by analyzing the next state of cells that neighbor currently living cells and don't transition to,
    /// or remain in, a living state in the next generation.
    /// </summary>
    public class ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy : IGenerationStrategy
    {
        private readonly IGameRules gameRules;

        /// <summary>
        /// Construct the strategy with <see cref="GameRules"/>.
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
