using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.Core.Notification;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateFriendDTO friend)
        {
            await _friendService.Post(friend);
            return Accepted();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<FriendDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var friends = await _friendService.GetAll();
            return friends.Any() ? Ok(friends) : NoContent();
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(FriendDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {
            var friend = await _friendService.GetById(id);
            return friend != null ? Ok(friend) : NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateFriendDTO friend)
        {
            await _friendService.Update(id, friend);
            return Accepted();
        }
    }
}