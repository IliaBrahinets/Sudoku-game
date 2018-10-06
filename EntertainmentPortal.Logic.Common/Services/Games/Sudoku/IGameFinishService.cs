using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku
{
    /// <summary>
    /// Exposes the operations that must be executed after the game finish.
    /// </summary>
    public interface IGameFinishService
    {
        /// <summary>
        /// Closes the game asynchronous.
        /// </summary>
        /// <param name="finishedPlayerBoardId">The finished player board identifier.</param>
        /// <returns></returns>
        Task CloseGameAsync(int finishedPlayerBoardId);
    }
}
