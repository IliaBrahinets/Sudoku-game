using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// A start game request model.
    /// </summary>
    public class StartGameRequest
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the level.
        /// </summary>
        /// <value>
        /// The name of the level.
        /// </value>
        public string LevelName { get; set; }
    }
}
