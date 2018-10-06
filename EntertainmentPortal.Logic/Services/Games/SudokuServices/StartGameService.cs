using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using AutoMapper;
using EntertainmentPortal.DataAccess.Common.Exceptions.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <summary>
    /// Sudoku game service.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.ISudokuGameService" />
    public class StartGameService : IStartGameService
    {
        private readonly ITemplateBoardService service;
        private readonly ILevelFactory factory;
        private readonly IAvailableLevelsProvider levelsProvider;
        private readonly IRepository<PlayerDbModel> playerRepository;
        private readonly IRepository<PlayerBoardDbModel> boardRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartGameService"/> class.
        /// </summary>
        /// <param name="service">The board service.</param>
        public StartGameService(ITemplateBoardService service, 
                                ILevelFactory factory,
                                IAvailableLevelsProvider levelsProvider,
                                IRepository<PlayerDbModel> playerRepository, 
                                IRepository<PlayerBoardDbModel> boardRepository, 
                                IMapper mapper, 
                                IUnitOfWork unitOfWork)
        {
            this.service = service;
            this.factory = factory;
            this.levelsProvider = levelsProvider;
            this.playerRepository = playerRepository;
            this.boardRepository = boardRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            service.Dispose();
        }

        /// <inheritdoc/>
        public async Task<PlayerBoardViewModel> GetUnfinishedGameAsync(int playerId)
        {
            try
            {
                var playerDb = await playerRepository.GetAsync(playerId);

                var player = mapper.Map<Player>(playerDb);

                if(player.LastUnfinishedGame == null)
                {
                    throw new InvalidOperationException("The given player has not the unfinished game");
                }

                return mapper.Map<PlayerBoardViewModel>(player.LastUnfinishedGame);
            }
            catch(EntityNotFoundException ex)
            {
                throw new PlayerNotFoundException($"Player by the specified id {playerId} was not found", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> IsUnfinishedGameExistAsync(int playerId)
        {
            try
            {
                var playerDb = await playerRepository.GetAsync(playerId);

                var player = mapper.Map<Player>(playerDb);

                if (player.LastUnfinishedGame == null)
                {
                    return false;
                }

                return true;
            }
            catch (EntityNotFoundException ex)
            {
                throw new PlayerNotFoundException($"Player by the specified id {playerId} was not found", ex);
            }
        }

        /// <inheritdoc/>
        public Task<IEnumerable<string>> GetAvailableDifficultyLevelsAsync()
        {
            return Task.FromResult(levelsProvider.GetLevels());
        }

        /// <inheritdoc/>
        public async Task<PlayerBoardViewModel> StartNewGameAsync(StartGameRequest request)
        {
            DifficultyLevel level = factory.CreateLevel(request.LevelName);

            var player = await playerRepository.FirstOrDefaultAsync(request.PlayerId);

            if(player == null)
            {
                throw new PlayerNotFoundException();
            }

            await boardRepository.DeleteAsync(board => board.PlayerId == player.Id);

            var templateBoardDb = await service.GetRandomTemplateBoardByLevelAsync(level);

            var templateBoard = mapper.Map<TemplateBoard>(templateBoardDb);

            var playerBoard = new PlayerBoard(templateBoard)
            {
                PlayerId = player.Id
            };

            var playerBoardDb = mapper.Map<PlayerBoardDbModel>(playerBoard);

            playerBoard.BoardId = await boardRepository.InsertAndGetIdAsync(playerBoardDb);

            return mapper.Map<PlayerBoardViewModel>(playerBoard);
        }
    }
}
