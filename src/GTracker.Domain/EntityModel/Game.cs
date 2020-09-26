using System;
using GTracker.Domain.Core.Models;

namespace GTracker.Domain.EntityModel
{
    public class Game : Entity
    {
        public string Name { get; set; }
        public DateTime AquisicionDate { get; set; }
        public string Kind { get; set; }
        public string Observation { get; set; }
    }
}