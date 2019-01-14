using System;
using System.Threading.Tasks;
using CommandLine;
using GameOfLife.Core.Engine.Strategy;
using GameOfLife.Core.Input;

namespace GameOfLife.Console
{
    /// <summary>
    /// Entry-point for the command-line version of the Game of Life.
    /// 
    /// Executes the game loop based on selection input type and displays
    /// output to the console.
    /// </summary>
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
                .WithNotParsed(errors => Environment.Exit(0));

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
