using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    // todo: tests and docs
    public class FileGameInputSource : IGameInputSource
    {
        private readonly string filePath;
        private readonly ICellParser cellParser;

        public FileGameInputSource(string filePath, ICellParser cellParser)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("A file path is required.", nameof(filePath));
            }

            this.filePath = filePath;
            this.cellParser = cellParser ?? throw new ArgumentNullException(nameof(cellParser));
        }

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
                    if (!this.cellParser.TryParseCellFromString(line, out Cell cell))
                    {
                        throw new InvalidDataException(
                            $"{this.filePath} contains malformed data. " +
                            "each line must be of the form (x, y) where x and y " +
                            "are 64-bit unsigned integers"); 
                    }

                    initialGameState.Add(cell);
                    line = await streamReader.ReadLineAsync();
                }
            }

            return initialGameState;
        }
    }
}
