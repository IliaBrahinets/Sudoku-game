using System.Collections.Generic;

namespace EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku
{
    /// <summary>
    /// Represents a model of a player board.
    /// </summary>
    public class PlayerBoardDbModel : Entity
    {
        /// <summary>
        /// Gets or sets the list of cells on the board.
        /// </summary>
        /// <value>
        /// The cell list.
        /// </value>
        public virtual ICollection<CellDbModel> CellList { get; set; }

        /// <summary>
        /// Gets or sets the template board identifier.
        /// </summary>
        /// <value>
        /// The template board identifier.
        /// </value>
        public int TemplateBoardId { get; set; }

        /// <summary>
        /// Gets or sets the board template.
        /// </summary>
        /// <value>
        /// The board template.
        /// </value>
        public virtual TemplateBoardDbModel TemplateBoard { get; set; }

        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// The player.
        /// </value>
        public virtual PlayerDbModel Player { get; set; }
    }
}
