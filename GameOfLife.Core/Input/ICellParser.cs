using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    // todo: docs
    public interface ICellParser
    {
        bool TryParseCellFromString(string input, out Cell cell);
    }
}
