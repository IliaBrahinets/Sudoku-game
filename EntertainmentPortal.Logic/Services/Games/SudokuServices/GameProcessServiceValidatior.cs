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
    /// Decorator of <see cref="IGameProcessService"/>, for validating.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.IGameProcessService" />
    public class GameProcessServiceValidator : IGameProcessService
    {
        private readonly IGameProcessService validatedService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameProcessServiceValidator"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public GameProcessServiceValidator(IGameProcessService service)
        {
            this.validatedService = service;
        }
        
        /// <inheritdoc/>
        public Task<PlayerBoardViewModel> GetPlayerBoardAsync(int playerBoardId)
        {
            return validatedService.GetPlayerBoardAsync(playerBoardId);
        }

        public Task<PlayerBoardViewModel> ResetPlayerBoardAsync(int playerBoardId)
        {
            return validatedService.ResetPlayerBoardAsync(playerBoardId);
        }


        /// <inheritdoc/>
        public Task<BoardStatus> GetBoardStatusAsync(int playerBoardId) => validatedService.GetBoardStatusAsync(playerBoardId);

        /// <inheritdoc/>
        public Task<BoardStatus> UpdateCellAndGetBoardStatusAsync(int playerBoardId, UpdateCellRequest request)
        {
            ValidateUpdateCellRequest(playerBoardId, request);

            return validatedService.UpdateCellAndGetBoardStatusAsync(playerBoardId, request);
        }
   
        /// <inheritdoc/>
        public Task<Cell> UpdateCellAsync(int playerBoardId, UpdateCellRequest request)
        {
            ValidateUpdateCellRequest(playerBoardId, request);

            return validatedService.UpdateCellAsync(playerBoardId, request);
        }

        /// <summary>
        /// Validates the update cell request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="CannotUpdateCellException">Invalid cell value</exception>
        private void ValidateUpdateCellRequest(int playerBoardId, UpdateCellRequest request)
        {
            if (request.Value == null || (request.Value.Value >= 1 && request.Value.Value <= 9))
            {
                return;
            }

            throw new CannotUpdateCellException("Invalid cell value");
        }
    }
}
