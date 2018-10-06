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
    public class PlayerBoard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerBoard"/> class.
        /// </summary>
        public PlayerBoard()
        {
            CellList = new List<Cell>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerBoard"/> class.
        /// </summary>
        /// <param name="board">The board.</param>
        public PlayerBoard(TemplateBoard board):this()
        {
            foreach(var templateCell in board.CellList)
            {
                var cell = new Cell(templateCell);

                if (!cell.IsConst)
                {
                    cell.Value = null;
                }

                this.CellList.Add(cell);
            }

            this.TemplateBoardId = board.BoardId;
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
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the template board identifier.
        /// </summary>
        /// <value>
        /// The template board identifier.
        /// </value>
        public int TemplateBoardId { get; set; }
    }
}
