using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// Represent a update cell request.
    /// </summary>
    public class UpdateCellRequest
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
        /// Gets or sets the value of the cell.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int? Value { get; set; }
    }
}
