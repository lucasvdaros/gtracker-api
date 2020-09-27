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
        private readonly IGameRepository _gameRepository;

        public GameService(IMapper mapper,
                            IMediatorHandler bus,
                            IGameRepository gameRepository)
        {
            _Mapper = mapper;
            _Bus = bus;
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<GameDTO>> GetAll()
        {
            return (await _gameRepository.GetAll())
                    .Select(f => _Mapper.Map<GameDTO>(f));            
        }

        public async Task<GameDTO> GetById(int id)
        {
            return _Mapper.Map<GameDTO>(await _gameRepository.GetById(id));
        }

        public async Task Post(CreateGameDTO game)
        {
            var registerCommand = _Mapper.Map<RegisterNewGameCommand>(game);
            await _Bus.SendCommand(registerCommand);
        }

        public async Task Update(int id, UpdateGameDTO game)
        {
            var updateCommand = _Mapper.Map<UpdateGameCommand>(game);
            updateCommand.Id = id;
            await _Bus.SendCommand(updateCommand);
        }
    }
}