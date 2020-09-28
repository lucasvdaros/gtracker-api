using System;
using System.Collections.Generic;

namespace GTracker.Domain.DTO.Loan
{
    public class CreateLoanDTO
    {
        public int FriendId { get; set; }
        public DateTime DateStart { get; set; }
        public string Observation { get; set; }
        public IList<int> GamesId { get; set; }

        public CreateLoanDTO()
        {
            GamesId = new List<int>();
        }
    }
}