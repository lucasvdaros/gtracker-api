using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.Interface.Repository;
using GTracker.Domain.Interface.Service;

namespace GTracker.Service
{
    public class FriendService : IFriendService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;
        private readonly IFriendRepository _friendRepository;

        public FriendService(IMapper mapper,
                            IMediatorHandler bus,
                            IFriendRepository friendRepository)
        {
            _Mapper = mapper;
            _Bus = bus;
            _friendRepository = friendRepository;
        }

        public async Task<IEnumerable<FriendDTO>> GetAll()
        {
            return (await _friendRepository.GetAll())
                    .Select(f => _Mapper.Map<FriendDTO>(f));
        }

        public async Task<FriendDTO> GetById(int id)
        {
            return _Mapper.Map<FriendDTO>(await _friendRepository.GetById(id));
        }

        public async Task Post(CreateFriendDTO friend)
        {
            var registerCommand = _Mapper.Map<RegisterNewFriendCommand>(friend);
            await _Bus.SendCommand(registerCommand);
        }

        public async Task Update(int id, UpdateFriendDTO friend)
        {               
            var updateCommand = _Mapper.Map<UpdateFriendCommand>(friend);
            updateCommand.Id = id;
            await _Bus.SendCommand(updateCommand);
        }
    }
}