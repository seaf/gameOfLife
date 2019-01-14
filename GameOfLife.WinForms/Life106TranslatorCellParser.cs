using System;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Input;

namespace GameOfLife.WinForms
{
    internal class Life106TranslatorCellParser : ICellParser
    {
        private readonly int originRow;
        private readonly int originColumn;

        public Life106TranslatorCellParser(int gridWidth, int gridHeight)
        {
            this.originColumn = gridWidth / 2;
            this.originRow = gridHeight / 2;
        }

        public bool TryParseCellFromString(string input, out Cell cell)
        {
            cell = null;
            var sections = input.Trim().Split(' ');
            if (sections.Length != 2 ||
                !long.TryParse(sections[0], out long column) ||
                !long.TryParse(sections[1], out long row))
            {
                return false;
            }

            cell = new Cell(
                Convert.ToUInt64(row + this.originRow),
                Convert.ToUInt64(column + this.originColumn));

            return true;
        }
    }
}
