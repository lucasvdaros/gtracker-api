using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Loan;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.DTO.Loan;
using GTracker.Domain.Interface.Repository;
using GTracker.Domain.Interface.Service;

namespace GTracker.Service
{
    public class LoanService : ILoanService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;
        private readonly ILoanRepository _loanRepository;

        public LoanService(IMapper mapper,
                            ILoanRepository loanRepository,
                            IMediatorHandler bus)
        {
            _Bus = bus;
            _Mapper = mapper;
            _loanRepository = loanRepository;
        }

        public async Task FinishLoan(int id, FinishLoanDTO loan)
        {
            var finishCommand = _Mapper.Map<FinishLoanCommand>(loan);
            finishCommand.LoanId = id;
            await _Bus.SendCommand(finishCommand);
        }

        public async Task<LoanDTO> GetById(int id)
        {
            return _Mapper.Map<LoanDTO>(await _loanRepository.GetById(id));
        }

        public async Task<IEnumerable<LoanDTO>> GetFiltered(int? friendId, DateTime? dtbeg, DateTime? dtend, int skip, int take)
        {
            return (await _loanRepository.GetFiltered(friendId, dtbeg, dtend, skip, take))
                   .Select(f => _Mapper.Map<LoanDTO>(f));
        }

        public async Task Post(CreateLoanDTO loan)
        {
            var registerCommand = _Mapper.Map<RegisterNewLoanCommand>(loan);
            await _Bus.SendCommand(registerCommand);
        }
    }
}