using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// Represents the create player request.
    /// </summary>
    public class CreateOrGetPlayerRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
