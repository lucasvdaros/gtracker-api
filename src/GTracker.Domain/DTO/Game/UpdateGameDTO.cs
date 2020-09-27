using System;

namespace GTracker.Domain.DTO.Game
{
    public class UpdateGameDTO
    {
        public string Name { get; set; }
        public DateTime? AquisicionDate { get; set; }
        public string Kind { get; set; }
        public string Observation { get; set; }
    }
}