using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    // todo: docs
    public interface IGameInputSource
    {
        Task<HashSet<Cell>> GetInitialGameState();
    }
}
