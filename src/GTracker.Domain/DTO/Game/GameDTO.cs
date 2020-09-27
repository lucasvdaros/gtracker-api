using System;

namespace GTracker.Domain.DTO.Game
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AquisicionDate { get; set; }
        public string Kind { get; set; }
        public string Observation { get; set; }
    }
}