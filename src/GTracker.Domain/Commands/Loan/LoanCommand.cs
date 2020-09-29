using System;
using GTracker.Domain.Core.Commands;

namespace GTracker.Domain.Commands.Loan
{
    public abstract class LoanCommand : Command
    {
        public int FriendId { get; set; }
        public DateTime DateStart { get; set; }
        public string Observation { get; set; }        
    }
}