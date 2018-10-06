using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels
{
    /// <summary>
    /// Represents the medium level of boards.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels.DifficultyLevel" />
    public class MediumLevel : DifficultyLevel
    {
        /// <inheritdoc />
        public override string LevelName => "Medium";

        /// <inheritdoc />
        protected override int LowerBound => 30;

        /// <inheritdoc />
        protected override int UpperBound => 50;
    }
}
