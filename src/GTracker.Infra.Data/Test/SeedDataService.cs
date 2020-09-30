using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;

namespace GTracker.Infra.Data.Test
{
    public class SeedDataService
    {
        private readonly GTrackerContext _context;
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;

        public SeedDataService(GTrackerContext context,
                               IUserRepository userRepository,
                               IGameRepository gameRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public async Task FeedDb()
        {
            var games = GetGames();

            if (games.ToList().Count != 0)
            {
                foreach (var game in games)
                    await _gameRepository.Add(game);
            }

            var user = new User
            {
                Name = "ADMIN",
                Login = "admin",
                Active = true,
                Password = "10000.i0wt/ndvvw0/T/Kop2S99A==.Uv33Y1sHv+QO05qdqvbKEg3A9pGkQqhvTiB3BRf69BA="
            };

            await _userRepository.Add(user);

            await _context.SaveChangesAsync();
        }

        public IList<Game> GetGames()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(dir + "/Test/games.json");

            return JsonSerializer.Deserialize<List<GameJson>>(json)
                .Select(a => new Game
                {
                    Name = a.Name,
                    AcquisicionDate = a.AcquisicionDate,
                    Kind = a.Kind,
                    Observation = a.Observation
                })
                .ToList();
        }

        public class GameJson
        {
            public string Name { get; set; }
            public DateTime AcquisicionDate { get; set; }
            public int Kind { get; set; }
            public string Observation { get; set; }
        }
    }
}