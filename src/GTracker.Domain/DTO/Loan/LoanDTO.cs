using System;
using System.Collections.Generic;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.DTO.Game;

namespace GTracker.Domain.DTO.Loan
{
    public class LoanDTO
    {
        public int Id { get; set; }
        public FriendDTO Friend { get; set; }
        public DateTime DateStart { get; set; }
        public string Observation { get; set; }
        public IList<GameDTO> Games { get; set; }

        public LoanDTO()
        {
            Games = new List<GameDTO>();
        }
    }
}