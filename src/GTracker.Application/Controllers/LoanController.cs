using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.DTO.Loan;
using GTracker.Domain.Enum;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int? friendId = null,
                                            [FromQuery] DateTime? dtbeg = null,
                                            [FromQuery] DateTime? dtend = null,
                                            [FromQuery] int? status = null,
                                            [FromQuery] int skip = 1,
                                            [FromQuery] int take = 12)
        {
            try
            {
                var loans = await _loanService.GetFiltered(friendId, dtbeg, dtend, status, skip, take);

                return loans.Count() != 0 ? (IActionResult)Ok(loans) : (IActionResult)NoContent();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {
            try
            {
                var loan = await _loanService.GetById(id);
                return loan != null ? (IActionResult)Ok(loan) : (IActionResult)NoContent();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch("finish/{id}")]
        [Authorize]
        public async Task<IActionResult> FinishLoan([FromRoute] int id, [FromBody] FinishLoanDTO loan)
        {
            try
            {
                await _loanService.FinishLoan(id, loan);
                return Accepted();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}