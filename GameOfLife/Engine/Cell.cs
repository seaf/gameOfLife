﻿using System;
using System.Collections.Generic;

namespace GameOfLife.Engine
{
    /// <summary>
    /// Representation of the game's cells, or grid coordinates.
    /// </summary>
    /// <remarks>The internal Tuple{ulong,ulong} is used to access trustworthy implementations of
    /// the Equals and GetHashCode methods while the class itself provides a type that can hold some
    /// game-specific logic and whose meaning within the context of the game is clear.</remarks>
    public class Cell : IEquatable<Cell>
    {
        private readonly Tuple<ulong, ulong> internalTuple;

        private readonly bool isMinRow;
        private readonly bool isMinCol;
        private readonly bool isMaxRow;
        private readonly bool isMaxCol;

        private readonly ulong reducedRowCoordinate;
        private readonly ulong reducedColumnCoordinate;
        private readonly ulong increasedRowCoordinate;
        private readonly ulong increasedColumnCoordinate;

        public Cell(ulong rowCoordinate, ulong columnCoordinate)
        {
            this.internalTuple = Tuple.Create(rowCoordinate, columnCoordinate);

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
        public ulong RowCoordinate => this.internalTuple.Item1;

        /// <summary>
        /// The column location of this cell in the game's 2D grid.
        /// </summary>
        public ulong ColumnCoordinate => this.internalTuple.Item2;

        /// <summary>
        /// Implementation of Equals.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>Whether or not this object is equal to the given one.</returns>
        public override bool Equals(object obj)
        {
            return this.internalTuple.Equals(obj);
        }

        public bool Equals(Cell other)
        {
            return this.internalTuple.Equals(other.internalTuple);
        }

        /// <summary>
        /// Implementation of GetHashCode.
        /// </summary>
        /// <returns>The computed hash code.</returns>
        public override int GetHashCode()
        {
            return this.internalTuple.GetHashCode();
        }

        /// <summary>
        /// Implementation of ToString.
        /// </summary>
        /// <returns>The string representation of this <see cref="Cell"/>.</returns>
        public override string ToString()
        {
            return this.internalTuple.ToString();
        }

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
