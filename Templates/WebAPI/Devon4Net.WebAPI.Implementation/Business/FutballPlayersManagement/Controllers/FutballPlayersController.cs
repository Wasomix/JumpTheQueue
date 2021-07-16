using Devon4Net.Infrastructure.Log;
using Devon4Net.Infrastructure.MediatR.Handler;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Commands;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Controllers
{
    /// <summary>
    /// Controller sample to implement the mediator pattern
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class FutballPlayersController : ControllerBase
    {
        private IMediatRHandler MediatRHandler { get; set; }

        public FutballPlayersController(IMediatRHandler mediatRHandler)
        {
            MediatRHandler = mediatRHandler;
        }

        /// <summary>
        /// Get all futball players
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/get_all_futball_players")]
        [ProducesResponseType(typeof(List<FutballPlayerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllFutballPlayers()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            Devon4NetLogger.Debug($"Executing {m.ReflectedType.Name}" +
                " from controller {m.Name}");
            var query = new GetAllFutballPlayersQuery();
            return Ok(await MediatRHandler.QueryAsync(query));
        }

        /// <summary>
        /// Create new futball player
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/add_futball_player")]
        [ProducesResponseType(typeof(FutballPlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddNewFutballPlayer(FutballPlayerDto futballPlayer)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            Devon4NetLogger.Debug($"Executing {m.ReflectedType.Name}" +
                " from controller {m.Name}");
            var command = new AddNewFutballPlayerCommand(futballPlayer);
            return Ok(await MediatRHandler.CommandAsync(command));
        }
    }
}
