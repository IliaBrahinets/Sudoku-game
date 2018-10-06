using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels
{
    /// <summary>
    /// Represents the easy level of boards.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels.DifficultyLevel" />
    public class EasyLevel : DifficultyLevel
    {
        /// <inheritdoc />
        public override string LevelName => "Easy";

        /// <inheritdoc />
        protected override int LowerBound => 3;

        /// <inheritdoc />
        protected override int UpperBound => 30;
    }
}
