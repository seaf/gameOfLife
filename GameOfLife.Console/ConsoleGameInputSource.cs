using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Input;

namespace GameOfLife.Console
{
    /// <summary>
    /// An <see cref="IGameInputSource"/> that reads input from the console and parses it using the
    /// provider <see cref="ICellParser"/>.
    /// </summary>
    internal class ConsoleGameInputSource : IGameInputSource
    {
        private readonly ICellParser cellParser;

        internal ConsoleGameInputSource(ICellParser cellParser)
        {
            this.cellParser = cellParser ?? throw new ArgumentNullException(nameof(cellParser));
        }

        /// <summary>
        /// Retrieve input for the game using a console interface.
        /// </summary>
        /// <returns>The set of living cells at the start of the game.</returns>
        public Task<HashSet<Cell>> GetInitialGameState()
        {
            var line = string.Empty;
            var initialGameState = new HashSet<Cell>();

            System.Console.WriteLine("---- Conway's Game of Life ----" + Environment.NewLine);
            System.Console.WriteLine(
                "Enter the coordinates (as unsigned 64-bit integers) " +
                "of initial living cells: (x, y)");

            System.Console.WriteLine($"Enter \"{InputConstants.InputEnd}\" to exit.");

            while (true)
            {
                System.Console.Write(
                    Environment.NewLine +
                    $"Enter Live Cell (or \"{InputConstants.InputEnd}\"): ");

                line = System.Console.ReadLine();
                if (line == InputConstants.InputEnd)
                {
                    break;
                }

                if (this.cellParser.TryParseCellFromString(line, out Cell inputCell))
                {
                    initialGameState.Add(inputCell);
                }
                else
                {
                    System.Console.WriteLine(
                        Environment.NewLine +
                        "A cell must be of the form (x, y) " +
                        "where x and y are 64-bit unsigned integers.");
                }
            }

            return Task.FromResult(initialGameState);
        }
    }
}
