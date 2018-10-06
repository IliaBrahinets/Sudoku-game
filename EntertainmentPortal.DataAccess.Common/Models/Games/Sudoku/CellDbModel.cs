using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku
{
    /// <summary>
    /// Represents a model of the cell of a board.
    /// </summary>
    public class CellDbModel:Entity
    {
        /// <summary>
        /// Gets or sets the x coordinate of the cell.
        /// </summary>
        /// <value>
        /// The x coordinate.
        /// </value>
        public int XCoordinate { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate of the cell.
        /// </summary>
        /// <value>
        /// The y coordinate.
        /// </value>
        public int YCoordinate { get; set; }

        /// <summary>
        /// Gets or sets the block number in which cell is located.
        /// </summary>
        /// <value>
        /// The block number.
        /// </value>
        public int BlockNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of the cell.
        /// </summary>
        /// <value>
        /// The value, null means that the cell is not filled.
        /// </value>
        public int? Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cell value must be filled by player or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if cell value must be filled by player; otherwise, <c>false</c>.
        /// </value>
        public bool IsConst { get; set; }

        /// <summary>
        /// Gets or sets the template board identifier.
        /// </summary>
        /// <value>
        /// The template board identifier.
        /// </value>
        public int? TemplateBoardId { get; set; }

        /// <summary>
        /// Gets or sets the board.
        /// </summary>
        /// <value>
        /// The board.
        /// </value>
        public TemplateBoardDbModel TemplateBoard { get; set; }

        /// <summary>
        /// Gets or sets the template board identifier.
        /// </summary>
        /// <value>
        /// The template board identifier.
        /// </value>
        public int? PlayerBoardId { get; set; }

        /// <summary>
        /// Gets or sets the board.
        /// </summary>
        /// <value>
        /// The board.
        /// </value>
        public PlayerBoardDbModel PlayerBoard { get; set; }
    }
}
