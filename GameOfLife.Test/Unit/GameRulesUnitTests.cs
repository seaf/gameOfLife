using System;
using FluentAssertions;
using GameOfLife.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Test.Unit
{
    // These tests could be combined using [DataRow} or similar data injection methods.
    // They have been kept separate to have descriptive names for each test case.
    [TestClass]
    public class GameRulesUnitTests
    {
        private const int TestBirthThreshold = 1;
        private const int TestSurvivalThreshold = 2;
        private const int TestSecondaryThreshold = 10;

        private readonly GameRules rulesUnderTest;

        public GameRulesUnitTests()
        {
            this.rulesUnderTest = new GameRules(
                new int[] { TestBirthThreshold, TestSecondaryThreshold },
                new int[] { TestSurvivalThreshold, TestSecondaryThreshold });
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ConstructGameRulesWithNullBirthThresholdsShouldThrow()
        {
            Action constructRules = () => new GameRules(
                birthThresholds: null,
                survivalThresholds: new int[] { TestSurvivalThreshold });

            constructRules.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("birthThresholds");
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ConstructGameRulesWithNullSurvivalThresholdsShouldThrow()
        {
            Action constructRules = () => new GameRules(
                birthThresholds: new int[] { TestBirthThreshold },
                survivalThresholds: null);

            constructRules.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("survivalThresholds");
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveStandardRulesAliveCellWithTwoAliveNeighborsShouldLive()
        {
            GameRules.StandardRulesInstance.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: 2).Should().BeTrue();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveStandardRulesAliveCellWithThreeAliveNeighborsShouldLive()
        {
            GameRules.StandardRulesInstance.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: 3).Should().BeTrue();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveStandardRulesDeadCellWithThreeAliveNeighborsShouldLive()
        {
            GameRules.StandardRulesInstance.ShouldCellLive(
                cellAlive: false,
                aliveNeighborCount: 3).Should().BeTrue();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveAliveCellNotEnoughLivingNeighborsShouldNotLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: TestSurvivalThreshold - 1).Should().BeFalse();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveAliveCellEnoughLivingNeighborsShouldLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: TestSurvivalThreshold).Should().BeTrue();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveAliveCellTooManyLivingNeighborsShouldNotLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: TestSurvivalThreshold + 1).Should().BeFalse();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveAliveCellMeetsOneSurvivalThresholdButNotAnotherShouldLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: TestSecondaryThreshold).Should().BeTrue();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveDeadCellNotEnoughLivingNeighborsShouldNotLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: false,
                aliveNeighborCount: TestBirthThreshold - 1).Should().BeFalse();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveDeadCellEnoughLivingNeighborsShouldLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: false,
                aliveNeighborCount: TestBirthThreshold).Should().BeTrue();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveDeadCellTooManyLivingNeighborsShouldNotLive()
        {
            this.rulesUnderTest.ShouldCellLive(
                cellAlive: false,
                aliveNeighborCount: TestBirthThreshold + 1).Should().BeFalse();
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ShouldCellLiveDeadCellMeetsOneBirthThresholdThresholdButNotAnotherShouldLive()
        {
            rulesUnderTest.ShouldCellLive(
                cellAlive: true,
                aliveNeighborCount: TestSecondaryThreshold).Should().BeTrue();
        }
    }
}
