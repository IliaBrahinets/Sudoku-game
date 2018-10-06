using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IGameFinishService" />
    public class GameFinishService : IGameFinishService
    {
        private readonly IRepository<PlayerBoardDbModel> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameStatisticsService statisticsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameFinishService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public GameFinishService(IRepository<PlayerBoardDbModel> repository, IUnitOfWork unitOfWork, IGameStatisticsService statisticsService)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.statisticsService = statisticsService;
        }

        /// <inheritdoc/>
        public async Task CloseGameAsync(int finishedPlayerBoardId)
        {
            await statisticsService.UpdateStatisticsAsync(finishedPlayerBoardId);
            await repository.DeleteAsync(finishedPlayerBoardId);
            await unitOfWork.CommitAsync();
        }
    }
}
