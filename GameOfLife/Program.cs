using System;
using System.Threading.Tasks;
using CommandLine;
using GameOfLife.Core.Engine.Strategy;
using GameOfLife.Core.Input;

namespace GameOfLife.Console
{
    // todo: docs
    public class Program
    {
        private static readonly IGenerationStrategy GenerationStrategy =
            new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();

        private static readonly ICellParser CellParser = new TupleFormatCellParser();

        internal static async Task Main(string[] args)
        {
            IGameInputSource gameInputSource = null;
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(
                    (options) =>
                    {
                        if (options.InputFile != null)
                        {
                            gameInputSource = new FileGameInputSource(options.InputFile, CellParser);
                        }
                        else
                        {
                            gameInputSource = new ConsoleGameInputSource(CellParser);
                        }
                    })
                .WithNotParsed(
                    (errors) =>
                    {
                        foreach (var error in errors)
                        {
                            System.Console.WriteLine(error);
                        }
                    });

            try
            {
                var liveCells = await gameInputSource.GetInitialGameState();
                if (liveCells.Count == 0)
                {
                    System.Console.WriteLine("No input found! Exiting simulation.");
                    PauseBeforeExit();
                }

                var generation = 1;
                while (true)
                {
                    System.Console.WriteLine($"Generation: {generation++}");

                    foreach (var cell in liveCells)
                    {
                        System.Console.WriteLine(cell);
                    }

                    System.Console.WriteLine(
                        "Hit ENTER to simulate the next generation (or " +
                        $"\"{InputConstants.InputEnd}\" to exit).");

                    var input = System.Console.ReadLine().Trim().ToLowerInvariant();
                    if (input == InputConstants.InputEnd)
                    {
                        break;
                    }

                    liveCells = GenerationStrategy.AdvanceGeneration(liveCells);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                PauseBeforeExit();
            }
        }

        private static void PauseBeforeExit()
        {
            System.Console.WriteLine("ENTER to exit.");
            System.Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
