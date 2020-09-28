using System;

namespace GTracker.Domain.EntityModel
{
    public class LoanGame
    {
        public int LoanId { get; set; }
        public int GameId { get; set; }
        public int LoanStatus { get; set; }
        public DateTime? DataEnd { get; set; }

        public Loan Loan { get; set; }
        public Game Game { get; set; }

        public LoanGame()
        {
            Loan = new Loan();
            Game = new Game();
        }
    }
}