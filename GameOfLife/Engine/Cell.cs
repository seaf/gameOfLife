using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    /// <summary>
    /// Representation of the game's cells, or grid coordinates.
    /// </summary>
    /// <remarks>This is essentially a named <see cref="Tuple"/> that contains some additional game-specific logic.
    /// By extending <see cref="Tuple<ulong, ulong"/> the class can leverage relevent and trustworthy implementations of all
    /// equality methods, and the GetHashCode method. Surface area for testing is reduced by not overriding these
    /// or implementing them separately and the <see cref="Cell"/> type can house game-speific logic and provide clearer
    /// meaning of the coordinates throughout the game code.</remarks>
    public class Cell : Tuple<ulong, ulong>
    {
        private readonly bool isMinRow;
        private readonly bool isMinCol;
        private readonly bool isMaxRow;
        private readonly bool isMaxCol;

        private readonly ulong reducedRowCoordinate;
        private readonly ulong reducedColumnCoordinate;
        private readonly ulong increasedRowCoordinate;
        private readonly ulong increasedColumnCoordinate;

        public Cell(ulong rowCoordinate, ulong columnCoordinate)
            : base(rowCoordinate, columnCoordinate)
        {
            // These could be properties that evaluate these expressions on each call
            // if using extra memory to store these values becomes a concern.
            this.isMinRow = rowCoordinate == ulong.MinValue;
            this.isMinCol = columnCoordinate == ulong.MinValue;
            this.isMaxRow = rowCoordinate == ulong.MaxValue;
            this.isMaxCol = columnCoordinate == ulong.MaxValue;

            this.reducedRowCoordinate = rowCoordinate - 1;
            this.reducedColumnCoordinate = columnCoordinate - 1;
            this.increasedRowCoordinate = rowCoordinate + 1;
            this.increasedColumnCoordinate = columnCoordinate + 1;
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
            if (!isMinRow)
            {
                if (!isMinCol)
                {
                    yield return new Cell(this.reducedRowCoordinate, this.reducedColumnCoordinate);
                }

                yield return new Cell(this.reducedRowCoordinate, this.ColumnCoordinate);

                if (!isMaxCol)
                {
                    yield return new Cell(this.reducedRowCoordinate, this.increasedColumnCoordinate);
                }
            }

            if (!isMinCol)
            {
                yield return new Cell(this.RowCoordinate, this.reducedColumnCoordinate);
            }

            if (!isMaxCol)
            {
                yield return new Cell(this.RowCoordinate, this.increasedColumnCoordinate);
            }

            if (!isMaxRow)
            {
                if (!isMinCol)
                {
                    yield return new Cell(this.increasedRowCoordinate, this.reducedColumnCoordinate);
                }

                yield return new Cell(this.increasedRowCoordinate, this.ColumnCoordinate);

                if (!isMaxCol)
                {
                    yield return new Cell(this.increasedRowCoordinate, this.increasedColumnCoordinate);
                }
            }
        }
    }
}
