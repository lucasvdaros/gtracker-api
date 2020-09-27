using System;
using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.DTO.User;
using GTracker.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GTracker.Application.Controllers
{
    [Route("gtracker/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin([FromBody] LoginUserDTO login)
        {
            try
            {
                var result = await _userService.Login(login);

                return result is null || !result.Authenticated ? (IActionResult)NotFound() : Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}