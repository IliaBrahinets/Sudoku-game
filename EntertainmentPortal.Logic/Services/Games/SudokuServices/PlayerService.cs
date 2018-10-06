using AutoMapper;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntertainmentPortal.DataAccess.Common.Exceptions.Games.Sudoku;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <summary>
    /// A player service.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IPlayerService" />
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<PlayerDbModel> repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public PlayerService(IUnitOfWork unitOfWork, IRepository<PlayerDbModel> repository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }


        /// <inheritdoc/>
        public async Task<PlayerViewModel> CreateOrGetPlayerAsync(CreateOrGetPlayerRequest request)
        {
            var dbPlayer = await repository.FirstOrDefaultAsync(p => p.Name == request.Name);

            if(dbPlayer == null)
            {
                dbPlayer = await repository.InsertAsync(
                    new PlayerDbModel
                    {
                        Name = request.Name
                    });

                await unitOfWork.CommitAsync();
            }

            var player = mapper.Map<Player>(dbPlayer);

            return mapper.Map<PlayerViewModel>(player);
        }

        /// <inheritdoc/>
        public async Task<PlayerViewModel> GetPlayerDataAsync(int playerId)
        {
            try
            {
                var dbPlayer = await repository.GetAsync(playerId);

                var player = mapper.Map<Player>(dbPlayer);

                return mapper.Map<PlayerViewModel>(player);
            }
            catch (EntityNotFoundException ex)
            {
                throw new PlayerNotFoundException("Player was not found", ex);
            }
        }
    }
}
