using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Game;

namespace GTracker.Domain.Interface.Service
{
    public interface IGameService
    {
        Task Post(CreateGameDTO game);
        Task<IEnumerable<GameDTO>> GetAll();
        Task<GameDTO> GetById(int id);
        Task<IEnumerable<GameDTO>> GetFiltered(string name, DateTime? dtbeg, DateTime? dtend, int? kind, int skip, int take);
        Task Update(int id, UpdateGameDTO game);
    }
}