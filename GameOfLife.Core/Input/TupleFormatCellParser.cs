using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    /// <summary>
    /// An <see cref="ICellParser"/> to create <see cref="Cell"/>s from strings in "tuple" or similar formats.
    /// </summary>
    public class TupleFormatCellParser : ICellParser
    {
        private const int ExpectedNumberOfCoordinates = 2;
        private const char CoordinateDelimiterChar = ',';

        private static readonly char[] CharactersToTrim = new [] {' ', '(', ')', '\t', '\r', '\f'};

        /// <summary>
        /// Attempts to create a <see cref="Cell"/> from an input string of the form "x, y" or "(x, y)" and
        /// compatible varitions.
        /// </summary>
        /// <param name="input">The string representation to parse.</param>
        /// <param name="cell">A reference to be populated with the <see cref="Cell"/> on success.</param>
        /// <returns><langword>True</langword> if a <see cref="Cell"/> was successfully created; otherwise
        /// <langword>false.</langword></returns>
        public bool TryParseCellFromString(string input, out Cell cell)
        {
            cell = null;
            var inputSections = input
                .Trim(CharactersToTrim)
                .Split(CoordinateDelimiterChar);

            if (inputSections.Length != ExpectedNumberOfCoordinates ||
                !ulong.TryParse(inputSections[0].Trim(CharactersToTrim), out ulong rowCoord) ||
                !ulong.TryParse(inputSections[1].Trim(CharactersToTrim), out ulong colCoord))
            {
                return false;
            }

            cell = new Cell(rowCoord, colCoord);
            return true;
        }
    }
}
