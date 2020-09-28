using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;

namespace GTracker.Domain.Interface.Repository
{
    public interface IGameRepository : IRepository<Game>
    {
        bool IsExistGame(int id);
        Task<IEnumerable<Game>> GetFiltered(string name, DateTime? dtbeg, DateTime? dtend, int? kind, int skip, int take);
        Task<IList<LoanGame>> GetLoanGamesById(IList<int> gamesId);
        bool IsExistGames(IList<int> gamesId);
    }
}