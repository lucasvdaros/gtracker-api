using System;
using System.Collections.Generic;
using GTracker.Domain.Core.Models;

namespace GTracker.Domain.EntityModel
{
    public class Game : Entity
    {
        public string Name { get; set; }
        public DateTime AcquisicionDate { get; set; }
        public int Kind { get; set; }
        public string Observation { get; set; }
        public IList<LoanGame> LoanGames { get; set; }

        public Game()
        {
            LoanGames = new List<LoanGame>();
        }
    }
}