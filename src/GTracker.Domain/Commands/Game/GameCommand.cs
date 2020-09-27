using System;
using GTracker.Domain.Core.Commands;

namespace GTracker.Domain.Commands.Game
{
    public abstract class GameCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; protected set; }
        public DateTime? AquisicionDate { get; protected set; }
        public int Kind { get; protected set; }
        public string Observation { get; protected set; }
    }
}