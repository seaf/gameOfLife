using System;
using System.Threading;
using GameOfLife.Core.Engine.Strategy;
using GameOfLife.Core.Input;

namespace GameOfLife
{
    public class Program
    {
        private static readonly IGenerationStrategy GenerationStrategy =
            new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();

        private static readonly IGameInputSource GameInputSource =
            new ConsoleGameInputSource(new TupleFormatCellParser());

        static void Main(string[] args)
        {
            // TODO: Consider reading from a file for easier editing of large input and providing set complex input
            var liveCells = GameInputSource.GetInitialGameState();

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
