using System;
using System.Linq;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// Container for birth and survival thresholds in the Game of Life.
    /// </summary>
    internal class GameRules : IGameRules
    {
        private readonly int[] birthThresholds;
        private readonly int[] survivalThresholds;

        private static readonly Lazy<GameRules> LazyStandardRulesInstance =
            new Lazy<GameRules>(() => new GameRules());

        private GameRules()
            : this(new int[] { 3 }, new int[] { 2, 3 })
        {
        }

        public GameRules(int[] birthThresholds, int[] survivalThresholds)
        {
            this.birthThresholds = birthThresholds ?? throw new ArgumentNullException(nameof(birthThresholds));
            this.survivalThresholds = survivalThresholds ?? throw new ArgumentNullException(nameof(survivalThresholds));
        }

        /// <summary>
        /// Gets the single default rules instance of this type.
        /// </summary>
        public static GameRules StandardRulesInstance => LazyStandardRulesInstance.Value;

        /// <summary>
        /// Determine whether a cell is alive in the next generation for the current game rules.
        /// </summary>
        /// <param name="cellAlive">Whether or not the cell is currently alive.</param>
        /// <param name="aliveNeighborCount">The number of alive neighbors the cell has.</param>
        /// <returns><langword>True</langword>If the cell is alive in the next generation,
        /// <langword>false</langword> otherwise.</returns>
        public bool ShouldCellLive(bool cellAlive, int aliveNeighborCount)
        {
            if (cellAlive)
            {
                return this.survivalThresholds.Contains(aliveNeighborCount);
            }

            return this.birthThresholds.Contains(aliveNeighborCount);
        }
    }
}
