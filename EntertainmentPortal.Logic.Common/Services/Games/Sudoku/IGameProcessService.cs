using System;
using System.Threading.Tasks;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku
{
    /// <summary>
    /// Game process service interface.
    /// </summary>
    public interface IGameProcessService
    {
        /// <summary>
        /// Gets the player board.
        /// </summary>
        /// <param name="playerBoardId">The player board identifier.</param>
        /// <exception cref="BoardNotFoundException">Thrown when the board by the specified id can not be found.</exception>
        /// <returns>A <see cref="PlayerBoardViewModel"/>.</returns>
        Task<PlayerBoardViewModel> GetPlayerBoardAsync(int playerBoardId);

        /// <summary>
        /// Resets to the initial state the player board.
        /// </summary>
        /// <param name="playerBoardId">The player board identifier.</param>
        /// <exception cref="BoardNotFoundException">Thrown when the board by the specified id can not be found.</exception>
        /// <returns>A <see cref="PlayerBoardViewModel"/>.</returns>
        Task<PlayerBoardViewModel> ResetPlayerBoardAsync(int playerBoardId);

        /// <summary>
        /// Updates the cell asynchronous.
        /// </summary>
        /// <param name="playerBoardId">The player board identifier.</param>
        /// <param name="request">The update request.</param>
        /// <exception cref="CannotUpdateCellException">Thrown when <see cref="Cell"/> can not be updated.</exception>
        /// <returns>
        /// A <see cref="Task{Cell}" />.
        /// </returns>
        Task<Cell> UpdateCellAsync(int playerBoardId, UpdateCellRequest request);

        /// <summary>
        /// Updates the cell and get the board status asynchronous.
        /// </summary>
        /// <param name="playerBoardId">The player board identifier.</param>
        /// <param name="request">The update request.</param>
        /// <exception cref="CannotUpdateCellException">Thrown when <see cref="Cell"/> can not be updated.</exception>
        /// <returns>
        /// A <see cref="Task{BoardStatus}" />.
        /// </returns>
        Task<BoardStatus> UpdateCellAndGetBoardStatusAsync(int playerBoardId, UpdateCellRequest request);

        /// <summary>
        /// Gets the player board status.
        /// </summary>
        /// <param name="playerBoardId">The player board identifier.</param>
        /// <exception cref="BoardNotFoundException">Thrown when the player board can not be found.</exception>
        /// <returns>
        /// A <see cref="Task{BoardStatus}" />.
        /// </returns>
        Task<BoardStatus> GetBoardStatusAsync(int playerBoardId);
    }
}
