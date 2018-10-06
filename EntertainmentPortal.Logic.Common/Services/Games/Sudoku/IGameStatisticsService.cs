using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku
{
    /// <summary>
    /// Exposes the feature of updating statistics after the game finish.
    /// </summary>
    public interface IGameStatisticsService
    {
        /// <summary>
        /// Get the top player and their statistics asynchronous.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{PlayerViewModel}"/>.</returns>
        Task<List<PlayerViewModel>> GetTopPlayersAsync();
        
        /// <summary>
        /// Updates the statistics asynchronous.
        /// </summary>
        /// <param name="finishedPlayerBoardId">The player board identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateStatisticsAsync(int finishedPlayerBoardId);
        
        
    }
}
