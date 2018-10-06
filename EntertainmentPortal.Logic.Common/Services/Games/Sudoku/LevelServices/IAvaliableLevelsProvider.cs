using System.Collections.Generic;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices
{
    /// <summary>
    /// The board difficulty levels provider.
    /// </summary>
    public interface IAvailableLevelsProvider
    {
        /// <summary>
        /// Provide with the board difficulty levels.  
        /// </summary>
        /// <returns>A <see cref="IEnumerable{srting}"/>, that contain the level names.</returns>
        IEnumerable<string> GetLevels();
    }
}