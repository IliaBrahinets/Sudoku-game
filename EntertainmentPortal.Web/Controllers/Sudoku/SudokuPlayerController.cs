using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using EntertainmentPortal.Web.CustomFilters.Games.Sudoku;
using NLog;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EntertainmentPortal.Web.Controllers.Sudoku
{
    [RoutePrefix("api/sudokuGame/players")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [SudokuExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SudokuPlayerController : ApiController
    {
        private readonly IPlayerService service;
        private readonly ILogger logger;

        public SudokuPlayerController(IPlayerService playerService, ILogger logger)
        {
            this.service = playerService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request data")]
        [SwaggerResponse(HttpStatusCode.OK, "Player was returned")]
        public async Task<IHttpActionResult> CreateOrGetPlayerAsync([FromBody] CreateOrGetPlayerRequest request)
        {
            try
            {
                var player = await service.CreateOrGetPlayerAsync(request);

                return Ok(player);
            }
            catch (InvalidPlayerDataException ex)
            {
                logger.Error(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NotFound, "Player was not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Player was returned")]
        public async Task<IHttpActionResult> GetPlayerDataAsync(int playerId)
        {
            try
            {
                var player = await service.GetPlayerDataAsync(playerId);

                return Ok(player);
            }
            catch (PlayerNotFoundException ex)
            {
                logger.Error(ex);
                return NotFound();
            }
        }
    }
}