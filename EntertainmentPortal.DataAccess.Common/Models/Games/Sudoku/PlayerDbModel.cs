using System.Collections.Generic;

namespace EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku
{
    /// <summary>
    /// Represents a model of a player.
    /// </summary>
    public class PlayerDbModel:Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of won easy games.
        /// </summary>
        public int EasyWinsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of won medium games.
        /// </summary>
        public int MediumWinsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of won hard games.
        /// </summary>
        public int HardWinsCount { get; set; }

        /// <summary>
        /// Gets or sets the unfinished games.
        /// </summary>
        public virtual ICollection<PlayerBoardDbModel> UnfinishedGames { get; set; }
    }
}
