using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices
{
    /// <summary>
    /// Exposes a feature of assigning a difficulty level to the specified <see cref="TemplateBoardDbModel"/>.
    /// </summary>
    public interface ILevelAssigner
    {
        /// <summary>
        /// Assigns level to the <see cref="TemplateBoardDbModel"/>.
        /// </summary>
        /// <param name="template">The template board.</param>
        /// <returns>A level of this board.</returns>
        DifficultyLevel Assign(TemplateBoardDbModel template);
    }
}
