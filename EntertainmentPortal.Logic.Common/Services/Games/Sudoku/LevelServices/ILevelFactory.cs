using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices
{
    /// <summary>
    /// A factory for creating concrete difficulty levele instances by name.
    /// </summary>
    public interface ILevelFactory
    {
        /// <summary>
        /// Creates the level.
        /// </summary>
        /// <param name="levelName">Name of the level.</param>
        /// <exception cref="LevelNotFoundException">Thrown when level can not be created.</exception>
        /// <returns></returns>
        DifficultyLevel CreateLevel(string levelName);
    }
}
