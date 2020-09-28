using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Loan;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.DTO.Loan;
using GTracker.Domain.Interface.Service;

namespace GTracker.Service
{
    public class LoanService : ILoanService
    {
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;

        public LoanService(IMapper mapper,
                           IMediatorHandler bus)
        {
            _Bus = bus;
            _Mapper = mapper;
        }

        public async Task Post(CreateLoanDTO loan)
        {
            var registerCommand = _Mapper.Map<RegisterNewLoanCommand>(loan);
            await _Bus.SendCommand(registerCommand);
        }
    }
}