using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    /// <summary>
    /// Standard rules for Conway's Game of Life.
    /// </summary>
    internal class StandardGameRules : IGameRules
    {
        private readonly List<int> birthThresholds;
        private readonly List<int> surviveThresholds;

        private static readonly Lazy<StandardGameRules> LazyInstance =
            new Lazy<StandardGameRules>(() => new StandardGameRules());

        private StandardGameRules()
        {
            this.birthThresholds = new List<int> { 3 };
            this.surviveThresholds = new List<int> { 2, 3 };
        }

        /// <summary>
        /// Gets the single instance of this type.
        /// </summary>
        public static StandardGameRules Instance => LazyInstance.Value;

        /// <summary>
        /// Determine whether a cell is alive in the next generation.
        /// </summary>
        /// <param name="cellAlive">Whether or not the cell is currently alive.</param>
        /// <param name="aliveNeighborCount">The number of alive neighbors cell has.</param>
        /// <returns><langword>True</langword>If the cell is alive in the next generation,
        /// <langword>false</langword> otherwise.</returns>
        public bool ShouldCellLive(bool cellAlive, int aliveNeighborCount)
        {
            if (cellAlive)
            {
                return this.surviveThresholds.Contains(aliveNeighborCount);
            }

            return this.birthThresholds.Contains(aliveNeighborCount);
        }
    }
}
