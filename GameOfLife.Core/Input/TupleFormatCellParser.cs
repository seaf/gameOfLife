using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    // todo: docs, parses (x,y)
    // todo: tests
    public class TupleFormatCellParser : ICellParser
    {
        private const int ExpectedNumberOfCoordinates = 2;
        private const char CoordinateDelimiterChar = ',';

        private static readonly char[] CharactersToTrim = new [] {' ', '(', ')', '\t', '\r', '\f'};

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
