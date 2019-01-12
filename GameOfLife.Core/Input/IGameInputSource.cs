using System.Collections.Generic;
using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    // todo: docs
    public interface IGameInputSource
    {
        HashSet<Cell> GetInitialGameState();
    }
}
