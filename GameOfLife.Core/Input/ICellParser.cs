using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    /// <summary>
    /// Operations to create game <see cref="Cell"/>s from other representations.
    /// </summary>
    public interface ICellParser
    {
        /// <summary>
        /// Attempts to create a <see cref="Cell"/> from the input string.
        /// </summary>
        /// <param name="input">The string representation to parse.</param>
        /// <param name="cell">A reference to be populated with the <see cref="Cell"/> on success.</param>
        /// <returns><langword>True</langword> if a <see cref="Cell"/> was successfully created; otherwise
        /// <langword>false.</langword></returns>
        bool TryParseCellFromString(string input, out Cell cell);
    }
}
