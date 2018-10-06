using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// A model to represent players board.
    /// </summary>
    public class PlayerBoardViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerBoard"/> class.
        /// </summary>
        public PlayerBoardViewModel()
        {
            CellList = new List<CellViewModel>();
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
        public List<CellViewModel> CellList { get; set; }

        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }
    }
}
