using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using NLog;
using Swashbuckle.Swagger.Annotations;
using EntertainmentPortal.Web.CustomFilters.Games.Sudoku;

namespace EntertainmentPortal.Web.Controllers.Sudoku
{
    [RoutePrefix("api/sudokuGame")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [SudokuExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SudokuGameController : ApiController
    {
        private readonly IStartGameService startService;
        private readonly IGameProcessService processService;
        private readonly IGameStatisticsService statisticsService;  
        private readonly ILogger logger;

        public SudokuGameController(IStartGameService startService, IGameProcessService processService, IGameStatisticsService statisticsService, ILogger logger)
        {
            this.startService = startService;
            this.processService = processService;
            this.statisticsService = statisticsService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("game/unfinishedGame/existenseStatus")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request data")]
        [SwaggerResponse(HttpStatusCode.OK, "Existence status was returned")]
        public async Task<IHttpActionResult> IsUnfinishedGameExistAsync(int playerId)
        {
            try
            {
                var existeneceStatus = await startService.IsUnfinishedGameExistAsync(playerId);

                return Ok(existeneceStatus);
            }
            catch (PlayerNotFoundException ex)
            {
                logger.Error(ex, $"Player with the specified id({playerId}) can not be found");
                return BadRequest("Invalid player id");
            }
        }

        [HttpGet]
        [Route("game/unfinishedGame")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request data")]
        [SwaggerResponse(HttpStatusCode.OK, "Sudoku game is created")]
        public async Task<IHttpActionResult> GetUnfinishedGameAsync(int playerId)
        {
            try
            {
                var board = await startService.GetUnfinishedGameAsync(playerId);

                return Ok(board);
            }
            catch (PlayerNotFoundException ex)
            {
                logger.Error(ex, $"Player with the specified id({playerId}) can not be found");
                return BadRequest("Invalid player id");
            }
            catch (InvalidOperationException ex)
            {
                logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("players/topPlayers")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.OK, "Top players were returned")]
        public async Task<IHttpActionResult> GetUnfinishedGameAsync()
        {
            var topPlayers = await statisticsService.GetTopPlayersAsync();

            return Ok(topPlayers);
        }

        [HttpGet]
        [Route("game/difficultyLevels")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.OK, "Levels was returned")]
        public async Task<IHttpActionResult> GetDifficultyLevelsAsync()
        {
            return Ok(await startService.GetAvailableDifficultyLevelsAsync());
        }
        
        [HttpPost]
        [Route("game")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request data")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Board not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Sudoku game is created")]
        public async Task<IHttpActionResult> StartNewGameAsync([FromBody] StartGameRequest request)
        {
            try
            {
                var board = await startService.StartNewGameAsync(request);

                return Ok(board);
            }
            catch (LevelNotFoundException ex)
            {
                logger.Error(ex, $"Invalid level name:{request.LevelName}");
                return BadRequest("Invalid level name");
            }
            catch (BoardNotFoundException ex)
            {
                logger.Error(ex, $"At the current moment a board with specified level does not exist, level:{request.LevelName}");
                return NotFound();
            }
            catch (PlayerNotFoundException ex)
            {
                logger.Error(ex, $"Player with the specified id({request.PlayerId}) can not be found");
                return BadRequest("Invalid player id");
            }
        }

        [HttpGet]
        [Route("game/{playerBoardId:int}")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Board not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Board was returned")]
        public async Task<IHttpActionResult> GetPlayerBoardAsync(int playerBoardId)
        {
            try
            {
                var board = await processService.GetPlayerBoardAsync(playerBoardId);

                return Ok(board);
            }
            catch (BoardNotFoundException ex)
            {
                logger.Error(ex);
                return NotFound();
            }
        }
        
        [HttpPut]
        [Route("game/{playerBoardId:int}/reset")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Board not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Board was returned")]
        public async Task<IHttpActionResult> ResetPlayerBoardAsync(int playerBoardId)
        {
            try
            {
                var board = await processService.ResetPlayerBoardAsync(playerBoardId);

                return Ok(board);
            }
            catch (BoardNotFoundException ex)
            {
                logger.Error(ex);
                return NotFound();
            }
        }
        
        [HttpPut]
        [Route("game/{playerBoardId:int}/cell")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request data")]
        [SwaggerResponse(HttpStatusCode.OK, "Cell is updated")]
        public async Task<IHttpActionResult> UpdateCellAsync(int playerBoardId, [FromBody] UpdateCellRequest request)
        {
            try
            {
                var cell = await processService.UpdateCellAsync(playerBoardId, request);

                return Ok(cell);
            }
            catch (CannotUpdateCellException ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("game/{playerBoardId:int}/cell/boardStatus")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Board not found")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request data")]
        [SwaggerResponse(HttpStatusCode.OK, "Cell is updated")]
        public async Task<IHttpActionResult> UpdateCellAndGetBoardStatusAsync(int playerBoardId, [FromBody] UpdateCellRequest request)
        {
            try
            {
                var status = await processService.UpdateCellAndGetBoardStatusAsync(playerBoardId, request);

                return Ok(status);
            }
            catch (CannotUpdateCellException ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (BoardNotFoundException ex)
            {
                logger.Error(ex, $"Board with {playerBoardId} can not be found.");
                return NotFound();
            }
        }

        [HttpGet]
        [Route("game/{playerBoardId:int}/boardStatus")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Board not found")]
        [SwaggerResponse(HttpStatusCode.OK, "The Player Board Status returned")]
        public async Task<IHttpActionResult> GetBoardStatusAsync(int playerBoardId)
        {
            try
            {
                var status = await processService.GetBoardStatusAsync(playerBoardId);

                return Ok(status);
            }
            catch (BoardNotFoundException ex)
            {
                logger.Error(ex, $"Board with {playerBoardId} can not be found.");
                return NotFound();
            }
        }

    }
}