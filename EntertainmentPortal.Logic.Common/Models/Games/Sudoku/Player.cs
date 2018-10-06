using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// A model to represent players data.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the game points.
        /// </summary>
        /// <value>
        /// The game points.
        /// </value>
        public Statistics GamePoints { get; set; } = new Statistics();

        /// <summary>
        /// Gets or sets the last unfinished game.
        /// </summary>
        /// <value>
        /// The last unfinished game.
        /// </value>
        public PlayerBoard LastUnfinishedGame { get; set; }
    }
}
