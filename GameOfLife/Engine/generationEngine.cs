using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    internal class GenerationEngine : IGenerationEngine
    {
        // TODO: These should live behind separate interface governing logic to compute next gen.
        private const int RebirthThreshold = 3;
        private const int StayAliveThreshold = 2;

        public HashSet<Tuple<ulong, ulong>> Advance(HashSet<Tuple<ulong, ulong>> liveCells)
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

            // TODO: This should be separated and abstracted behind an interface so different algorithms to determining live cells can be injected.
            foreach (var candidateCellAndAliveNeighborCount in cellsWithNonZeroLivingNeighbors)
            {
                if (candidateCellAndAliveNeighborCount.Value == RebirthThreshold ||
                    (candidateCellAndAliveNeighborCount.Value == StayAliveThreshold && liveCells.Contains(candidateCellAndAliveNeighborCount.Key)))
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
