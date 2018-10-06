using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using FluentValidation;
using System.Collections.Generic;
using System;
using EntertainmentPortal.DataAccess.Common.Exceptions.Games.Sudoku;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <summary>
    /// Exposes a functionality to handle the sudoku game process.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IGameProcessService" />
    public class GameProcessService : IGameProcessService
    {
        private readonly IRepository<CellDbModel> cells;
        private readonly IRepository<PlayerBoardDbModel> boards;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameFinishService finishService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameProcessService"/> class.
        /// </summary>
        /// <param name="cells">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public GameProcessService(IRepository<PlayerBoardDbModel> boards, 
                                  IRepository<CellDbModel> cells, 
                                  IMapper mapper, 
                                  IUnitOfWork unitOfWork,
                                  IGameFinishService finishService)
        {
            this.mapper = mapper;
            this.cells = cells;
            this.boards = boards;
            this.unitOfWork = unitOfWork;
            this.finishService = finishService;
        }

        /// <inheritdoc/>
        public async Task<PlayerBoardViewModel> GetPlayerBoardAsync(int playerBoardId)
        {
            try
            {
                var playerBoardDb = await boards.GetAsync(playerBoardId);

                var playerBoard = mapper.Map<PlayerBoard>(playerBoardDb);

                return mapper.Map<PlayerBoardViewModel>(playerBoard);
            }
            catch (EntityNotFoundException ex)
            {
                throw new BoardNotFoundException($"Board by the specified id({playerBoardId}) was not found", ex);
            }
        }

        /// <inheritdoc />
        public async Task<PlayerBoardViewModel> ResetPlayerBoardAsync(int playerBoardId)
        {
            try
            {
                var playerBoardDb = await boards.GetAsync(playerBoardId);
                
                foreach(var cell in playerBoardDb.CellList)
                {
                    if (!cell.IsConst)
                    {
                        cell.Value = null;
                    }
                }
                
                await unitOfWork.CommitAsync();

                var playerBoard = mapper.Map<PlayerBoard>(playerBoardDb);

                return mapper.Map<PlayerBoardViewModel>(playerBoard);
            }
            catch (EntityNotFoundException ex)
            {
                throw new BoardNotFoundException($"Board by the specified id({playerBoardId}) was not found", ex);
            }
        }

        /// <inheritdoc />
        async Task<Cell> IGameProcessService.UpdateCellAsync(int playerBoardId, UpdateCellRequest request)
        {
            var cellDb = await UpdateCellAsync(playerBoardId, request);

            return mapper.Map<Cell>(cellDb);
        }

        /// <inheritdoc />
        public async Task<BoardStatus> UpdateCellAndGetBoardStatusAsync(int playerBoardId, UpdateCellRequest request)
        {
            var cellDb = await UpdateCellAsync(playerBoardId, request);

            return await GetBoardStatusAsync(playerBoardId);
        }

        private async Task<CellDbModel> UpdateCellAsync(int playerBoardId, UpdateCellRequest request)
        {
            try
            {
                var cellDb = await cells.SingleAsync(cell => cell.PlayerBoardId == playerBoardId &&
                                                          cell.XCoordinate == request.XCoordinate &&
                                                          cell.YCoordinate == request.YCoordinate);
                 
                if (cellDb.IsConst == true)
                {
                    throw new CannotUpdateCellException("Cell is const");
                }

                cellDb.Value = request.Value;

                await unitOfWork.CommitAsync();

                return cellDb;
            }
            catch (EntityNotFoundException ex)
            {
                throw new CannotUpdateCellException("Can not find any mathcing cell to update", ex);
            }
        }

        /// <inheritdoc />
        async Task<BoardStatus> IGameProcessService.GetBoardStatusAsync(int playerBoardId) => await GetBoardStatusAsync(playerBoardId);

        private async Task<BoardStatus> GetBoardStatusAsync(int playerBoardId)
        {
            try
            {
                var playerBoardDb = await boards.GetAsync(playerBoardId);

                var isNotFilled = playerBoardDb.CellList.Any(cell => cell.Value == null);

                if (isNotFilled)
                {
                    
                    return BoardStatus.InProgress;
                }

                var templateBoardDb = playerBoardDb.TemplateBoard;

                bool areEqual = AreCellsEqual(mapper.Map<List<Cell>>(playerBoardDb.CellList),
                                              mapper.Map<List<Cell>>(templateBoardDb.CellList));

                if (areEqual)
                {
                    await finishService.CloseGameAsync(playerBoardId);
                    return BoardStatus.Complete;
                }

                return BoardStatus.Invalid;
            }
            catch (EntityNotFoundException ex)
            {
                throw new BoardNotFoundException("Player board can not be found", ex);
            }
        }

        private bool AreCellsEqual(IEnumerable<Cell> value1, IEnumerable<Cell> value2)
        {
           return value1.All(cell1 => cell1.Value == value2.First(cell2 => cell2.XCoordinate == cell1.XCoordinate && 
                                                                           cell1.YCoordinate == cell2.YCoordinate).Value);
        }

    }
}
