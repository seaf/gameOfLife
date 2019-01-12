using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Input;

namespace GameOfLife
{
    // todo: docs, tests
    internal class ConsoleGameInputSource : IGameInputSource
    {
        private readonly ICellParser cellParser;

        internal ConsoleGameInputSource(ICellParser cellParser)
        {
            this.cellParser = cellParser ?? throw new ArgumentNullException(nameof(cellParser));
        }

        public Task<HashSet<Cell>> GetInitialGameState()
        {
            var line = string.Empty;
            var initialGameState = new HashSet<Cell>();

            Console.WriteLine("---- Conway's Game of Life ----" + Environment.NewLine);
            Console.WriteLine(
                "Enter the coordinates (as unsigned 64-bit integers) " +
                "of initial living cells: (x, y)");

            Console.WriteLine($"Enter \"{InputConstants.InputEnd}\" to exit.");

            while (true)
            {
                Console.Write(
                    Environment.NewLine +
                    $"Enter Live Cell (or \"{InputConstants.InputEnd}\"): ");

                line = Console.ReadLine();
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
                    Console.WriteLine(
                        Environment.NewLine +
                        "A cell must be of the form (x, y) " +
                        "where x and y are 64-bit unsigned integers.");
                }
            }

            return Task.FromResult(initialGameState);
        }
    }
}
