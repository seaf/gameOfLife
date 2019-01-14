using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    /// <summary>
    /// A source of input for the Game of Life that reads the set of intial living
    /// cells from a file of the appropriate format.
    /// </summary>
    public class FileGameInputSource : IGameInputSource
    {
        private readonly string filePath;
        private readonly ICellParser cellParser;

        /// <summary>
        /// Create a <see cref="FileGameInputSource"/> for the specified file
        /// and parsing method.
        /// </summary>
        /// <param name="filePath">The path to an input file.</param>
        /// <param name="cellParser">The parser to use.</param>
        public FileGameInputSource(string filePath, ICellParser cellParser)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("A file path is required.", nameof(filePath));
            }

            this.filePath = filePath;
            this.cellParser = cellParser ?? throw new ArgumentNullException(nameof(cellParser));
        }

        /// <summary>
        /// Retrieve initial game input from the specified file.
        /// </summary>
        /// <returns>The set of living cells at the start of the game.</returns>
        public async Task<HashSet<Cell>> GetInitialGameState()
        {
            if (!File.Exists(this.filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var initialGameState = new HashSet<Cell>();
            using (var streamReader = new StreamReader(filePath))
            {
                string line = await streamReader.ReadLineAsync();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line) &&
                        !line.StartsWith(InputConstants.Comment))
                    {
                        if (!this.cellParser.TryParseCellFromString(line, out Cell cell))
                        {
                            throw new InvalidDataException(
                                $"{this.filePath} contains malformed data. " +
                                "each line must be of the form (x, y) where x and y " +
                                "are 64-bit unsigned integers");
                        }

                        initialGameState.Add(cell);
                    }

                    line = await streamReader.ReadLineAsync();
                }
            }

            return initialGameState;
        }
    }
}
