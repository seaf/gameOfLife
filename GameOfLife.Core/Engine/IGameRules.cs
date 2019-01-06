namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// Abstract representation of the rules of the game for determining which cell's
    /// should live so variations of the game can be supported.
    /// </summary>
    /// <remarks>Considered exposing the collections of birth and survival thresholds individually,
    /// but it wasn't as natural to make the collections immutable and still easily check membership in them.</remarks>
    public interface IGameRules
    {
        /// <summary>
        /// Determine whether a cell is alive in the next generation.
        /// </summary>
        /// <param name="cellAlive">Whether or not the cell is currently alive.</param>
        /// <param name="aliveNeighborCount">The number of alive neighbors cell has.</param>
        /// <returns><langword>True</langword>If the cell is alive in the next generation,
        /// <langword>false</langword> otherwise.</returns>
        bool ShouldCellLive(bool cellAlive, int aliveNeighborCount);
    }
}
