using GameOfLife.Engine;
using GameOfLife.Engine.Strategy;
using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Program
    {
        private const string INPUT_DONE = "done";

        private static readonly IGenerationStrategy generationStrategy = new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();

        static void Main(string[] args)
        {
            // TODO: Consider reading from a file for easier editing of large input and providing set complex input
            var liveCells = new HashSet<Cell>();
            while (true)
            {
                Console.WriteLine("Enter coordinates (as unsigned 64-bit integers) of a living cell, separated by a comma (e.g. x,y). Enter \"done\" to finish:");

                var line = ReadProcessedLine();
                if (line == INPUT_DONE)
                {
                    break;
                }

                var coords = line.Split(',');
                if (coords.Length != 2)
                {
                    Console.WriteLine("Coordinates must be of the form \"x,y\".");
                    continue;
                }

                if (!ulong.TryParse(coords[0], out ulong x) || !ulong.TryParse(coords[1], out ulong y))
                {
                    Console.WriteLine($"Unable to parse coordinates. x: {coords[0]}, y: {coords[1]}.");
                    continue;
                }

                liveCells.Add(new Cell(x, y));
            }

            if (liveCells.Count == 0)
            {
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

                Console.WriteLine("Hit ENTER to advance the generation, or \"done\" to quit.");
                var line = ReadProcessedLine();
                if (line == INPUT_DONE)
                {
                    return;
                }

                liveCells = generationStrategy.AdvanceGeneration(liveCells);
            }
        }

        private static string ReadProcessedLine()
        {
            return Console.ReadLine().Trim().ToLowerInvariant();
        }
    }
}
