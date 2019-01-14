namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// A contract for interacting with the rules of the Game of Life.
    /// </summary>
    /// 
    /// <remarks>
    /// Considered exposing the collections of birth and survival thresholds individually,
    /// but it wasn't as natural to make the collections immutable and still easily check membership in them.
    /// </remarks>
    public interface IGameRules
    {
        /// <summary>
        /// Determine whether or not a cell is alive in the next generation of the game.
        /// </summary>
        /// <param name="cellAlive">Whether or not the cell is currently alive.</param>
        /// <param name="aliveNeighborCount">The number of livig cells adjacent to this one.</param>
        /// <returns><langword>True</langword>If the cell is alive in the next generation,
        /// <langword>false</langword> otherwise.</returns>
        bool ShouldCellLive(bool cellAlive, int aliveNeighborCount);
    }
}
