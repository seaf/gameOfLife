using System;
using System.Collections.Generic;

namespace GameOfLife.Engine.Strategy
{
    /// <summary>
    /// Computes the next generation of alive cells in the Game of Life by creating a mapping of cells that have
    /// a non-zero number of adjacent alive cells (i.e. in their neighborhood) to the number of alive adjacent cells they have.
    /// 
    /// Once this mapping is complete, walk the entries collecting the cells that are born or survive based on the game's rules.
    /// 
    /// This approach uses a linear [O(n), where n is the number of live cells] amount of additional memory.
    /// This may be problematic for game states with a large number of live cells.
    /// 
    /// Computation is also linear in n. For each live cell, we may add up to nine neighboring cells with counts to the mapping.
    /// In the worst case, this mapping will contain 9n entries which is still O(n) to walk.
    /// </summary>
    internal class StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy : IGenerationStrategy
    {
        private readonly IGameRules gameRules;

        /// <summary>
        /// Construct the strategy with <see cref="StandardGameRules"/>.
        /// </summary>
        public StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy()
            : this(StandardGameRules.Instance)
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
        public HashSet<Tuple<ulong, ulong>> AdvanceGeneration(HashSet<Tuple<ulong, ulong>> liveCells)
        {
            var newGeneration = new HashSet<Tuple<ulong, ulong>>();
            var cellsWithNonZeroLivingNeighbors = new Dictionary<Tuple<ulong, ulong>, int>();
            foreach (var cell in liveCells)
            {
                foreach (var neighbor in this.GetValidNeighbors(cell))
                {
                    if (!cellsWithNonZeroLivingNeighbors.TryGetValue(neighbor, out int count))
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

        /// <summary>
        /// An iterator over the collection of all neighbors of a given cell that exist within the game grid.
        /// </summary>
        /// <param name="cell">The cell whose neighbors are wanted</param>
        /// <returns>The neighboring cells</returns>
        private IEnumerable<Tuple<ulong, ulong>> GetValidNeighbors(Tuple<ulong, ulong> cell)
        {
            // TODO: Consider moving to an extension method, or create a Cell class that contains this logic and these fields.
            var isMinRow = cell.Item1 == ulong.MinValue;
            var isMinCol = cell.Item2 == ulong.MinValue;
            var isMaxRow = cell.Item1 == ulong.MaxValue;
            var isMaxCol = cell.Item2 == ulong.MaxValue;

            var reducedXCoord = cell.Item1 - 1;
            var reducedYCoord = cell.Item2 - 1;
            var increasedXCoord = cell.Item1 + 1;
            var increasedYCoord = cell.Item2 + 1;

            if (!isMinRow)
            {
                if (!isMinCol)
                {
                    yield return Tuple.Create(reducedXCoord, reducedYCoord);
                }

                yield return Tuple.Create(reducedXCoord, cell.Item2);

                if (!isMaxCol)
                {
                    yield return Tuple.Create(reducedXCoord, increasedYCoord);
                }
            }

            if (!isMinCol)
            {
                yield return Tuple.Create(cell.Item1, reducedYCoord);
            }

            if (!isMaxCol)
            {
                yield return Tuple.Create(cell.Item1, increasedYCoord);
            }

            if (!isMaxRow)
            {
                if (!isMinCol)
                {
                    yield return Tuple.Create(increasedXCoord, reducedYCoord);
                }

                yield return Tuple.Create(increasedXCoord, cell.Item2);

                if (!isMaxCol)
                {
                    yield return Tuple.Create(increasedXCoord, increasedYCoord);
                }
            }
        }
    }
}
