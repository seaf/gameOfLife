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

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationLoafStillLifeShouldRemainUnchanged(IGenerationStrategy strategyUnderTest)
        {
            var loaf = new HashSet<Cell> {
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 0),
                new Cell(1, 3),
                new Cell(2, 1),
                new Cell(2, 3),
                new Cell(3, 2)};

            var nextGen = strategyUnderTest.AdvanceGeneration(loaf);
            nextGen.Should().BeEquivalentTo(loaf);
        }

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationBoatStillLifeShouldRemainUnchanged(IGenerationStrategy strategyUnderTest)
        {
            var boat = new HashSet<Cell> {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(1, 0),
                new Cell(1, 2),
                new Cell(2, 1)};

            var nextGen = strategyUnderTest.AdvanceGeneration(boat);
            nextGen.Should().BeEquivalentTo(boat);
        }

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationTubStillLifeShouldRemainUnchanged(IGenerationStrategy strategyUnderTest)
        {
            var tub = new HashSet<Cell> {
                new Cell(0, 1),
                new Cell(1, 0),
                new Cell(1, 2),
                new Cell(2, 1)};

            var nextGen = strategyUnderTest.AdvanceGeneration(tub);
            nextGen.Should().BeEquivalentTo(tub);
        }

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationBlinkerOscillatorShouldRepeatInTwoGenerations(IGenerationStrategy strategyUnderTest)
        {
            var blinker = new HashSet<Cell> {
                new Cell(0, 1),
                new Cell(1, 1),
                new Cell(2, 1)};

            AssertOsscillatorRepeatsInTwoGenerations(blinker, strategyUnderTest);
        }

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationToadOscillatorShouldRepeatInTwoGenerations(IGenerationStrategy strategyUnderTest)
        {
            var toad = new HashSet<Cell> {
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2)};

            AssertOsscillatorRepeatsInTwoGenerations(toad, strategyUnderTest);
        }

        [DynamicData(nameof(StrategiesWithStandardRules))]
        [DataTestMethod, TestCategory(TestCategories.Unit)]
        public void AdvanceGenerationBeaconOscillatorShouldRepeatInTwoGenerations(IGenerationStrategy strategyUnderTest)
        {
            var beacon = new HashSet<Cell> {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(3, 2),
                new Cell(3, 3)};

            AssertOsscillatorRepeatsInTwoGenerations(beacon, strategyUnderTest);
        }

        private static void AssertOsscillatorRepeatsInTwoGenerations(HashSet<Cell> initialState, IGenerationStrategy strategyUnderTest)
        {
            var gen1 = strategyUnderTest.AdvanceGeneration(initialState);
            gen1.Should().NotBeEquivalentTo(initialState);

            var gen2 = strategyUnderTest.AdvanceGeneration(gen1);
            gen2.Should().BeEquivalentTo(initialState);
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
