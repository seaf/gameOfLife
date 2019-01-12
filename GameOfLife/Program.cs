using System;
using System.Threading;
using System.Threading.Tasks;
using GameOfLife.Core.Engine.Strategy;
using GameOfLife.Core.Input;

namespace GameOfLife
{
    public class Program
    {
        private static readonly IGenerationStrategy GenerationStrategy =
            new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();

        // TODO: add command line parser and option to select input source
        private static readonly IGameInputSource GameInputSource =
            new FileGameInputSource(
                @"REPLACEME",
                new TupleFormatCellParser());

        static async Task Main(string[] args)
        {
            var liveCells = await GameInputSource.GetInitialGameState();
            if (liveCells.Count == 0)
            {
                Console.WriteLine("No input found! Exiting simulation.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            var generation = 1;
            while (true)
            {
                Console.WriteLine($"Generation: {generation++}");

                foreach (var cell in liveCells)
                {
                    Console.WriteLine(cell);
                }

                Console.WriteLine(
                    "Hit ENTER to simulate the next generation (or " +
                    $"\"{InputConstants.InputEnd}\" to exit).");

                var input = Console.ReadLine().Trim().ToLowerInvariant();
                if (input == InputConstants.InputEnd)
                {
                    break;
                }

                liveCells = GenerationStrategy.AdvanceGeneration(liveCells);
            }
        }
    }
}
