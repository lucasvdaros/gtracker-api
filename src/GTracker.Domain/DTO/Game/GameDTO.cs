using System;
using System.Collections.Generic;

namespace GTracker.Domain.DTO.Game
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AcquisicionDate { get; set; }
        public int Kind { get; set; }
        public string Observation { get; set; }

        public IList<int> Status { get; set; }
        public IList<DateTime?> DataTerminoEmprestimo { get; set; }

        public GameDTO()
        {
            Status = new List<int>();
            DataTerminoEmprestimo = new List<DateTime?>();
        }
    }
}