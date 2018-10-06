using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <summary>
    /// Template board service.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IBoardService" />
    public class TemplateBoardService : ITemplateBoardService
    {
        private IRepository<TemplateBoardDbModel> repository;

        private Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateBoardService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public TemplateBoardService(IRepository<TemplateBoardDbModel> repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            repository.Dispose();
        }

        /// <inheritdoc/>
        public async Task<TemplateBoardDbModel> GetRandomTemplateBoardByLevelAsync(DifficultyLevel level)
        {
            List<TemplateBoardDbModel> boardDbModels = await repository.GetAllListAsync(level.IsMatchLevelExpression()).ConfigureAwait(false);

            if (boardDbModels.Count == 0) 
            {
                throw new BoardNotFoundException();
            }

            var boardDbModel = boardDbModels[random.Next(0, boardDbModels.Count)];

            return boardDbModel;
        }
    }
}
