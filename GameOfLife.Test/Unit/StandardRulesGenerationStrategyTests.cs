using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Engine;
using GameOfLife.Engine.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test.Unit
{
    [TestClass]
    public class StandardRulesGenerationStrategyTests
    {
        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationBlockStillLifeShouldRemainUnchanged(IGenerationStrategy strategyUnderTest)
        {
            var block = new HashSet<Cell> {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(1, 0),
                new Cell(1, 1)};

            var nextGen = strategyUnderTest.AdvanceGeneration(block);
            nextGen.Should().BeEquivalentTo(block);
        }

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationBeehiveStillLifeShouldRemainUnchanged(IGenerationStrategy strategyUnderTest)
        {
            var beehive = new HashSet<Cell> {
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 0),
                new Cell(1, 3),
                new Cell(2, 1),
                new Cell(2, 2)}; 

            var nextGen = strategyUnderTest.AdvanceGeneration(beehive);
            nextGen.Should().BeEquivalentTo(beehive);
        }

        private static IEnumerable<object[]> StrategiesWithStandardRules
        {
            get
            {
                yield return new object[] { new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy() };
                yield return new object[] { new StoreCountsForAllCellsWithAliveNeighborsGenerationStrategy() };
            }
        }
    }
}
