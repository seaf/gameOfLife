using System;
using System.Collections.Generic;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// Representation of the game's cells, or grid coordinates.
    /// </summary>
    /// 
    /// <remarks>
    /// This is essentially a named <see cref="Tuple"/> that contains some additional game-specific logic.
    /// By extending <see cref="Tuple<ulong, ulong"/> the class can leverage relevent and trustworthy implementations of all
    /// equality methods and the GetHashCode method. Surface area for testing is reduced by not overriding these
    /// or implementing them separately and the <see cref="Cell"/> type can house game-speific logic and provide clearer
    /// meaning of the coordinates throughout the game code.
    /// 
    /// When retriving valid neighbors of this Cell, a few expressions are evaluated multiple times as opposed to storing the value
    /// after one evaluation. This is done to save memory as there could be a large number of cells in memory per generation of the game.
    /// </remarks>
    public class Cell : Tuple<ulong, ulong>
    {
        public Cell(ulong rowCoordinate, ulong columnCoordinate)
            : base(rowCoordinate, columnCoordinate)
        {
        }

        /// <summary>
        /// The row location of this cell in the game's 2D grid.
        /// </summary>
        public ulong RowCoordinate => this.Item1;

        /// <summary>
        /// The column location of this cell in the game's 2D grid.
        /// </summary>
        public ulong ColumnCoordinate => this.Item2;

        /// <summary>
        /// An iterator over the collection of this cell's neighbors that exist within the game's grid.
        /// </summary>
        /// <returns>The neighboring cells</returns>
        public IEnumerable<Cell> FindValidNeighbors()
        {
            if (this.RowCoordinate != ulong.MinValue)
            {
                if (this.ColumnCoordinate != ulong.MinValue)
                {
                    yield return new Cell(this.RowCoordinate - 1, this.ColumnCoordinate - 1);
                }

                yield return new Cell(this.RowCoordinate - 1, this.ColumnCoordinate);

                if (this.ColumnCoordinate != ulong.MaxValue)
                {
                    yield return new Cell(this.RowCoordinate - 1, this.ColumnCoordinate + 1);
                }
            }

            if (this.ColumnCoordinate != ulong.MinValue)
            {
                yield return new Cell(this.RowCoordinate, this.ColumnCoordinate - 1);
            }

            if (this.ColumnCoordinate != ulong.MaxValue)
            {
                yield return new Cell(this.RowCoordinate, this.ColumnCoordinate + 1);
            }

            if (this.RowCoordinate != ulong.MaxValue)
            {
                if (this.ColumnCoordinate != ulong.MinValue)
                {
                    yield return new Cell(this.RowCoordinate + 1, this.ColumnCoordinate - 1);
                }

                yield return new Cell(this.RowCoordinate + 1, this.ColumnCoordinate);

                if (this.ColumnCoordinate != ulong.MaxValue)
                {
                    yield return new Cell(this.RowCoordinate + 1, this.ColumnCoordinate + 1);
                }
            }
        }
    }
}
