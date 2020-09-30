using System;
using GTracker.Domain.Core.Commands;

namespace GTracker.Domain.Commands.Game
{
    public abstract class GameCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? AcquisicionDate { get; set; }
        public int Kind { get; set; }
        public string Observation { get; set; }
    }
}