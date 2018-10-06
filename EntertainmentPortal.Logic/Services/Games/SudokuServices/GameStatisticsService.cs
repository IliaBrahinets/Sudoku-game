using AutoMapper;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IGameStatisticsService" />
    public class GameStatisticsService : IGameStatisticsService
    {
        private readonly IRepository<PlayerBoardDbModel> boardRepository;
        private readonly IRepository<PlayerDbModel> playerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILevelAssigner levelAssigner;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStatisticsService"/> class.
        /// </summary>
        /// <param name="boardRepository">The board repository.</param>
        /// <param name="playerRepository">The player repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="levelAssigner">The level assigner.</param>
        /// <param name="mapper">The mapper.</param>
        public GameStatisticsService(IRepository<PlayerBoardDbModel> boardRepository, 
                                     IRepository<PlayerDbModel> playerRepository, 
                                     IUnitOfWork unitOfWork,
                                     ILevelAssigner levelAssigner, 
                                     IMapper mapper)
        {
            this.boardRepository = boardRepository;
            this.playerRepository = playerRepository;
            this.unitOfWork = unitOfWork;
            this.levelAssigner = levelAssigner;
            this.mapper = mapper;
        }

        public async Task<List<PlayerViewModel>> GetTopPlayersAsync()
        {
            var topPlayerDb = await playerRepository.ExecuteQueryAsync(GetTopByBestCriteria(playerRepository.GetAll()));
            
            var topPlayers = mapper.Map<List<Player>>(topPlayerDb);

            return mapper.Map<List<PlayerViewModel>>(topPlayers);
        }

        private IQueryable<PlayerDbModel> GetTopByBestCriteria(IQueryable<PlayerDbModel> playersDb)
        {
            const int topCount = 10;
            return playersDb.OrderByDescending(playerDb => playerDb.HardWinsCount)
                            .ThenByDescending(playerDb => playerDb.MediumWinsCount)
                            .ThenByDescending(playerDb => playerDb.EasyWinsCount).Take(topCount);
        } 

        /// <inheritdoc/>
        public async Task UpdateStatisticsAsync(int finishedPlayerBoardId)
        {
            var playerBoardDb = await boardRepository.GetAsync(finishedPlayerBoardId);

            var diffLevel = levelAssigner.Assign(playerBoardDb.TemplateBoard);

            var playerDb = playerBoardDb.Player;

            var player = mapper.Map<Player>(playerDb);

            player.GamePoints.AddWonGame(diffLevel);

            playerDb = mapper.Map(player, playerDb);

            await playerRepository.UpdateAsync(playerDb);

            await unitOfWork.CommitAsync();
            
        }
    }
}
