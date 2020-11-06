using System;

namespace GTracker.Domain.DTO.Game
{
    public class CreateGameDTO
    {
        public string Name { get; set; }
        public DateTime? AcquisicionDate { get; set; }
        public string Kind { get; set; }
        public string Observation { get; set; }
    }
}