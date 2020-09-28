using System;
using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Loan;
using GTracker.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GTracker.Application.Controllers
{
    [Route("gtracker/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CreateLoanDTO loan)
        {
            try
            {
                await _loanService.Post(loan);
                return Accepted();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}