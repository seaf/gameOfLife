using System;
using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Engine;
using GameOfLife.Engine.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOfLife.Test.Unit
{
    [TestClass]
    public class ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategyUnitTests
    {
        private readonly Mock<IGameRules> mockGameRules;
        private readonly ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy strategyUnderTest;

        public ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategyUnitTests()
        {
            this.mockGameRules = new Mock<IGameRules>();
            this.strategyUnderTest = new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy(this.mockGameRules.Object);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategyWithNullRulesShouldThrow()
        {
            Action construct = () => new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy(gameRules: null);
            construct.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("gameRules");
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationShouldCallGameRulesExpectedNumberOfTimesWithExpectedStateAndLiveNeighborCounts()
        {
            this.mockGameRules.Setup(x => x.ShouldCellLive(It.IsAny<bool>(), It.IsAny<int>())).Returns(false);

            // Same row, adjacent columns
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2);

            var nextGen = strategyUnderTest.AdvanceGeneration(new HashSet<Cell> { cell1, cell2 });

            this.mockGameRules.Verify(x => x.ShouldCellLive(true, 1), Times.Exactly(2));
            this.mockGameRules.Verify(x => x.ShouldCellLive(false, 2), Times.Exactly(8));
            this.mockGameRules.Verify(x => x.ShouldCellLive(false, 1), Times.Exactly(6));
        }
    }
}
