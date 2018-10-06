using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;
using System;
using System.Collections.Generic;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// A template board model.
    /// </summary>
    public class TemplateBoard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateBoard"/> class.
        /// </summary>
        public TemplateBoard()
        {
            CellList = new List<Cell>();
        }

        /// <summary>
        /// Gets or sets the board identifier.
        /// </summary>
        /// <value>
        /// The board identifier.
        /// </value>
        public int BoardId { get; set; }

        /// <summary>
        /// Gets or sets the list of cells on the board.
        /// </summary>
        /// <value>
        /// The cell list.
        /// </value>
        public List<Cell> CellList { get; set; }

        /// <summary>
        /// Gets or sets the difficulty level.
        /// </summary>
        /// <value>
        /// The difficulty level.
        /// </value>
        public DifficultyLevel DifficultyLevel { get; set; }
    }
}
