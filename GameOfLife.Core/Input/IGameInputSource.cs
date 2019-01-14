using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfLife.Core.Engine;

namespace GameOfLife.Core.Input
{
    /// <summary>
    /// Operations defined on a source of input for the starting game state.
    /// </summary>
    public interface IGameInputSource
    {
        /// <summary>
        /// Retrieve input for the game.
        /// </summary>
        /// <returns>The set of living cells at the start of the game.</returns>
        Task<HashSet<Cell>> GetInitialGameState();
    }
}
