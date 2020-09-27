using System;
using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace GTracker.Application.Controllers
{
    [Route("gtracker/[controller]")]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpPost]        
        public async Task<ActionResult> Post([FromBody] CreateFriendDTO friend)
        {
            try
            {
                await _friendService.Post(friend);
                return Accepted();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}