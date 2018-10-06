using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku
{
    /// <summary>
    /// Sudoku game service interface.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IStartGameService : IDisposable
    {
        /// <summary>
        /// Provide with the board difficulty levels asynchronous.  
        /// </summary>
        /// <returns>A <see cref="IEnumerable{srting}"/>, that contain the level names.</returns>
        Task<IEnumerable<string>> GetAvailableDifficultyLevelsAsync();
        
        /// <summary>
        /// Starts the new game asynchronous.
        /// </summary>
        /// <param name="request">The request for game start.</param>
        /// <exception cref="BoardNotFoundException">Thrown when <see cref="TemplateBoard"/> with specified level can not be found.</exception>
        /// <exception cref="PlayerNotFoundException">Thrown when a player by the specified player id can not be found.</exception>
        /// <returns>A <see cref="Task{PlayerBoardViewModel}"/>.</returns>
        Task<PlayerBoardViewModel> StartNewGameAsync(StartGameRequest request);
        
        /// <summary>
        /// Determines whether the unfinished game of the specified player exists.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <returns>A <see cref="Task{bool}"/>.</returns>
        /// <exception cref="PlayerNotFoundException">Thrown when a player by the specified player id can not be found.</exception>
        Task<bool> IsUnfinishedGameExistAsync(int playerId);

        /// <summary>
        /// Gets the unfinished game of the specified player.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <returns>A <see cref="Task{PlayerBoardViewModel}"/>.</returns>
        /// <exception cref="PlayerNotFoundException">Thrown when a player by the specified player id can not be found.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the unfinished game is not exist.</exception>
        Task<PlayerBoardViewModel> GetUnfinishedGameAsync(int playerId);
    }
}
