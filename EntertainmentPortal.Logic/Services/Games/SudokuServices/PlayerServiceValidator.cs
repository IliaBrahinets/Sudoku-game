using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices
{
    /// <summary>
    /// Decorator of <see cref="IPlayerService"/>, for validating.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IPlayerService" />
    public class PlayerServiceValidator : IPlayerService
    {
        private readonly IPlayerService validatedService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerServiceValidator"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public PlayerServiceValidator(IPlayerService service)
        {
            this.validatedService = service;
        }

        /// <inheritdoc/>
        public async Task<PlayerViewModel> CreateOrGetPlayerAsync(CreateOrGetPlayerRequest request)
        {
            if (String.IsNullOrEmpty(request.Name))
            {
                throw new InvalidPlayerDataException("Name is empty!");
            }

            const int maxLength = 3;

            if(request.Name.Length < maxLength)
            {
                throw new InvalidPlayerDataException($"Length must be more than {maxLength}");
            }

            return await validatedService.CreateOrGetPlayerAsync(request);
        }

        /// <inheritdoc/>
        public async Task<PlayerViewModel> GetPlayerDataAsync(int playerId)
        {
            return await validatedService.GetPlayerDataAsync(playerId);
        }
    }
}
