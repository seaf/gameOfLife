using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife.Engine;
using GameOfLife.Engine.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOfLife.Test.Unit
{
    [TestClass]
    public class GenerationStrategyUnitTests
    {
        private static Mock<IGameRules> MockGameRules = new Mock<IGameRules>();

        [TestCleanup]
        public void TestCleanup()
        {
            // Reset the Mock following a test.
            MockGameRules = new Mock<IGameRules>();
        }

        [DynamicData(nameof(StrategiesWithMockedRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationFromNoLivingCellsShouldResultInNoLivingCells(IGenerationStrategy strategyUnderTest)
        {
            strategyUnderTest.AdvanceGeneration(new HashSet<Cell>()).Should().BeEmpty();
        }

        [DynamicData(nameof(StrategiesWithMockedRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationFromSingleLivingCellShouldResultInNoLivingCellsWhenNoneShouldLive(IGenerationStrategy strategyUnderTest)
        {
            var nextGen = strategyUnderTest.AdvanceGeneration(new HashSet<Cell> { new Cell(0, 0) }).Should().BeEmpty();
        }

        [DynamicData(nameof(StrategiesWithMockedRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationFromTwoLiveCellsWithDisparateNeighborhoodsShouldIncludeAllNeighbors(IGenerationStrategy strategyUnderTest)
        {
            MockGameRules.Setup(x => x.ShouldCellLive(It.IsAny<bool>(), It.IsAny<int>())).Returns(true);

            // Not adjacent
            var cell1 = new Cell(10, 20);
            var cell2 = new Cell(50, 70);

            var nextGen = strategyUnderTest.AdvanceGeneration(new HashSet<Cell> { cell1, cell2 });
            nextGen.Should().BeEquivalentTo(new HashSet<Cell>(cell1.FindValidNeighbors().Union(cell2.FindValidNeighbors())));
        }

        [DynamicData(nameof(StrategiesWithMockedRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationFromTwoLiveCellsWithOverlappingNeighborhoodsShouldIncludeAllNeighborsWithoutDuplicates(IGenerationStrategy strategyUnderTest)
        {
            MockGameRules.Setup(x => x.ShouldCellLive(It.IsAny<bool>(), It.IsAny<int>())).Returns(true);

            // Neighbors in column 2 overlap
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 3);

            var nextGen = strategyUnderTest.AdvanceGeneration(new HashSet<Cell> { cell1, cell2 });
            nextGen.Should().BeEquivalentTo(cell1.FindValidNeighbors().Union(cell2.FindValidNeighbors()));
        }

        private static IEnumerable<object[]> StrategiesWithMockedRules
        {
            get
            {
                yield return new object[] { new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy(MockGameRules.Object) };
                yield return new object[] { new StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy(MockGameRules.Object) };
            }
        }
    }
}
