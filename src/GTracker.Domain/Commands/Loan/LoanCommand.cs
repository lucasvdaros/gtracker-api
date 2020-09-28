using System;
using System.Collections.Generic;
using GTracker.Domain.Core.Commands;

namespace GTracker.Domain.Commands.Loan
{
    public abstract class LoanCommand : Command
    {
        public int FriendId { get; set; }
        public DateTime DateStart { get; set; }
        public string Observation { get; set; }
        public IList<int> GamesId { get; set; }

        public LoanCommand(IList<int> gamesId)
        {
            GamesId = gamesId;
        }
    }
}