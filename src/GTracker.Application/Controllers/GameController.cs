using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Game;
using GTracker.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GTracker.Application.Controllers
{
    [Route("gtracker/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CreateGameDTO game)
        {
            try
            {
                await _gameService.Post(game);
                return Accepted();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var games = await _gameService.GetAll();
                return games.Count() != 0 ? (IActionResult)Ok(games) : (IActionResult)NoContent();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {
            try
            {
                var city = await _gameService.GetById(id);
                return city != null ? (IActionResult)Ok(city) : (IActionResult)NoContent();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }        
    }
}