using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku
{
    /// <summary>
    /// A player service interface.
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Create and get or just get a player.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="Task{PlayerBoardViewModel}"/> that represents a created or existed player.</returns>
        /// <exception cref="InvalidPlayerDataException">Thrown when provided data is invalid.</exception>
        Task<PlayerViewModel> CreateOrGetPlayerAsync(CreateOrGetPlayerRequest request);

        /// <summary>
        /// Gets the player data.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <returns>A <see cref="Task{PlayerBoardViewModel}"/> that represents the player data.</returns>
        /// <exception cref="PlayerNotFoundException">Thrown when a player was not found.</exception>
        Task<PlayerViewModel> GetPlayerDataAsync(int playerId);
    }
}
