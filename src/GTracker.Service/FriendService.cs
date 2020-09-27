using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.Interface.Service;

namespace GTracker.Service
{
    public class FriendService : IFriendService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;

        public FriendService(IMapper mapper,
                            IMediatorHandler bus)
        {
            _Mapper = mapper;
            _Bus = bus;
        }

        // public Task<FriendDTO> Post(CreateFriendDTO friend)
        // {
        //     var registerCommand = _Mapper.Map<RegisterNewFriendCommand>(friend);
        //     return (Task<FriendDTO>)_Bus.SendCommand(registerCommand);
        // }
    }
}