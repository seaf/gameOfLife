using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test.Unit
{
    [TestClass]
    public class CellUnitTests
    {
        private const int NonBoundaryRow = 10;
        private const int NonBoundaryCol = 33;

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ConstructCellShouldSetCoordinates()
        {
            var cell = new Cell(NonBoundaryRow, NonBoundaryCol);

            cell.RowCoordinate.Should().Be(NonBoundaryRow);
            cell.Item1.Should().Be(NonBoundaryRow);
            cell.ColumnCoordinate.Should().Be(NonBoundaryCol);
            cell.Item2.Should().Be(NonBoundaryCol);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsNonBoundaryRowMinimumColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(NonBoundaryRow, ulong.MinValue).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(NonBoundaryRow - 1, ulong.MinValue),
                    new Cell(NonBoundaryRow - 1, ulong.MinValue + 1),
                    new Cell(NonBoundaryRow, ulong.MinValue + 1),
                    new Cell(NonBoundaryRow + 1, ulong.MinValue),
                    new Cell(NonBoundaryRow + 1, ulong.MinValue + 1),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsNonBoundaryRowNonBoundaryColumnShouldReturnAllNeighbors()
        {
            var neighbors = new Cell(NonBoundaryRow, NonBoundaryCol).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(NonBoundaryRow - 1, NonBoundaryCol - 1),
                    new Cell(NonBoundaryRow - 1, NonBoundaryCol),
                    new Cell(NonBoundaryRow - 1, NonBoundaryCol + 1),
                    new Cell(NonBoundaryRow, NonBoundaryCol - 1),
                    new Cell(NonBoundaryRow, NonBoundaryCol + 1),
                    new Cell(NonBoundaryRow + 1, NonBoundaryCol - 1),
                    new Cell(NonBoundaryRow + 1, NonBoundaryCol),
                    new Cell(NonBoundaryRow + 1, NonBoundaryCol + 1),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsNonBoundaryRowMaximumColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(NonBoundaryRow, ulong.MaxValue).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(NonBoundaryRow - 1, ulong.MaxValue - 1),
                    new Cell(NonBoundaryRow - 1, ulong.MaxValue),
                    new Cell(NonBoundaryRow, ulong.MaxValue - 1),
                    new Cell(NonBoundaryRow + 1, ulong.MaxValue - 1),
                    new Cell(NonBoundaryRow + 1, ulong.MaxValue),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsMinimumRowMinimumColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(ulong.MinValue, ulong.MinValue).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(ulong.MinValue, ulong.MinValue + 1),
                    new Cell(ulong.MinValue + 1, ulong.MinValue),
                    new Cell(ulong.MinValue + 1, ulong.MinValue + 1),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsMinimumRowNonBoundaryColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(ulong.MinValue, NonBoundaryCol).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(ulong.MinValue, NonBoundaryCol - 1),
                    new Cell(ulong.MinValue, NonBoundaryCol + 1),
                    new Cell(ulong.MinValue + 1, NonBoundaryCol - 1),
                    new Cell(ulong.MinValue + 1, NonBoundaryCol),
                    new Cell(ulong.MinValue + 1, NonBoundaryCol + 1),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsMinimumRowMaximumColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(ulong.MinValue, ulong.MaxValue).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(ulong.MinValue, ulong.MaxValue - 1),
                    new Cell(ulong.MinValue + 1, ulong.MaxValue - 1),
                    new Cell(ulong.MinValue + 1, ulong.MaxValue),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsMaximumRowMinimumColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(ulong.MaxValue, ulong.MinValue).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(ulong.MaxValue - 1, ulong.MinValue),
                    new Cell(ulong.MaxValue - 1, ulong.MinValue + 1),
                    new Cell(ulong.MaxValue, ulong.MinValue + 1),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsMaximumRowNonBoundaryColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(ulong.MaxValue, NonBoundaryCol).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(ulong.MaxValue - 1, NonBoundaryCol - 1),
                    new Cell(ulong.MaxValue - 1, NonBoundaryCol),
                    new Cell(ulong.MaxValue - 1, NonBoundaryCol + 1),
                    new Cell(ulong.MaxValue, NonBoundaryCol - 1),
                    new Cell(ulong.MaxValue, NonBoundaryCol + 1),
                });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void FindValidNeighborsMaximumRowMaximumColumnShouldExcludeOutOfBoundsNeighbors()
        {
            var neighbors = new Cell(ulong.MaxValue, ulong.MaxValue).FindValidNeighbors().ToList();

            neighbors.Should().BeEquivalentTo(
                new List<Cell>
                {
                    new Cell(ulong.MaxValue - 1, ulong.MaxValue - 1),
                    new Cell(ulong.MaxValue - 1, ulong.MaxValue),
                    new Cell(ulong.MaxValue, ulong.MaxValue - 1),
                });
        }
    }
}
