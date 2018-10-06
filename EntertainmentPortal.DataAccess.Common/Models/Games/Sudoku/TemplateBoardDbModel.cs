using System.Collections.Generic;

namespace EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku
{ 
    /// <summary>
    /// Represents a model of a template board.
    /// </summary>
    public class TemplateBoardDbModel:Entity
    {
        /// <summary>
        /// Gets or sets the empty cells count.
        /// </summary>
        /// <value>
        /// The empty cells count.
        /// </value>
        public int EmptyCellsCount { get; set; }

        /// <summary>
        /// Gets or sets the list of cells on the board.
        /// </summary>
        /// <value>
        /// The cell list.
        /// </value>
        public virtual ICollection<CellDbModel> CellList { get; set; }
    }
}
