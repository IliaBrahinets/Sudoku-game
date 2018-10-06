using System;
using System.Threading.Tasks;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;

namespace EntertainmentPortal.Logic.Common.Services.Games.Sudoku
{
    /// <summary>
    /// Template board service interface.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ITemplateBoardService : IDisposable
    {
        /// <summary>
        /// Gets all boards by level asynchronous.
        /// </summary>
        /// <returns>A <see cref="Task{TemplateBoardDbModel}"/>.</returns>
        Task<TemplateBoardDbModel> GetRandomTemplateBoardByLevelAsync(DifficultyLevel level);
    }
}
