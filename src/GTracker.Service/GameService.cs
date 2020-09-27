using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Game;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.DTO.Game;
using GTracker.Domain.Interface.Service;

namespace GTracker.Service
{
    public class GameService : IGameService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;

        public GameService(IMapper mapper,
                            IMediatorHandler bus)
        {
            _Mapper = mapper;
            _Bus = bus;
        }

        public async Task Post(CreateGameDTO game)
        {
            var registerCommand = _Mapper.Map<RegisterNewGameCommand>(game);
            await _Bus.SendCommand(registerCommand);
        }
    }
}