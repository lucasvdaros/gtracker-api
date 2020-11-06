using System;

namespace GTracker.Domain.DTO.Game
{
    public class UpdateGameDTO
    {
        public string Name { get; set; }
        public DateTime? AcquisicionDate { get; set; }
        public int Kind { get; set; }
        public string Observation { get; set; }
    }
}