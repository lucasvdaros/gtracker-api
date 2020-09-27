using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Game;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.DTO.Game;
using GTracker.Domain.Interface.Repository;
using GTracker.Domain.Interface.Service;

namespace GTracker.Service
{
    public class GameService : IGameService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;
        private readonly IGameRepository _gameRespository;

        public GameService(IMapper mapper,
                            IMediatorHandler bus,
                            IGameRepository gameRespository)
        {
            _Mapper = mapper;
            _Bus = bus;
            _gameRespository = gameRespository;
        }

        public async Task<IEnumerable<GameDTO>> GetAll()
        {
            return (await _gameRespository.GetAll())
                    .Select(f => _Mapper.Map<GameDTO>(f));            
        }

        public async Task Post(CreateGameDTO game)
        {
            var registerCommand = _Mapper.Map<RegisterNewGameCommand>(game);
            await _Bus.SendCommand(registerCommand);
        }
    }
}