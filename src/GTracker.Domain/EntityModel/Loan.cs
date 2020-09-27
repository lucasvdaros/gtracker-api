using System;
using System.Collections.Generic;
using GTracker.Domain.Core.Models;

namespace GTracker.Domain.EntityModel
{
    public class Loan : Entity
    {
        public int FriendId { get; set; }
        public Friend Friend { get; set; }
        public DateTime DateStart { get; set; }
        public string Observation { get; set; }

        public IList<LoanGame> LoanGames { get; set; }

        public Loan()
        {
            LoanGames = new List<LoanGame>();
        }
    }
}