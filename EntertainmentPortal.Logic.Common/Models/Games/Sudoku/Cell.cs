using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// A cell model. 
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Gets or sets the cell identifier.
        /// </summary>
        public int CellId { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="cell">The cell.</param>
        public Cell(Cell cell)
        {
            this.XCoordinate = cell.XCoordinate;
            this.YCoordinate = cell.YCoordinate;
            this.BlockNumber = cell.BlockNumber;
            this.Value = cell.Value;
            this.IsConst = cell.IsConst;
        }

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
    }
}
