using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels
{
    /// <summary>
    /// Represents the hard level of boards.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels.DifficultyLevel" />
    public class HardLevel : DifficultyLevel
    {
        /// <inheritdoc />
        public override string LevelName => "Hard";

        /// <inheritdoc />
        protected override int LowerBound => 50;

        /// <inheritdoc />
        protected override int UpperBound => 65;
    }
}
