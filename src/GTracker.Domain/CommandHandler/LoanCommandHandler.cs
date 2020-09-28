using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Loan;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.Core.Notification;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Enum;
using GTracker.Domain.Interface.Repository;
using MediatR;

namespace GTracker.Domain.CommandHandler
{
    public class LoanCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLoanCommand, bool>
    {
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _Mapper;
        private readonly ILoanRepository _loanRepository;
        private readonly IGameRepository _gameRepository;
        private readonly DomainNotificationHandler _notifications;

        public LoanCommandHandler(IUnitOfWork uow,
                                IMediatorHandler bus,
                                IMapper mapper,
                                ILoanRepository loanRepository,
                                IGameRepository gameRepository,
                                INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _Bus = bus;
            _Mapper = mapper;
            _loanRepository = loanRepository;
            _gameRepository = gameRepository;
            _notifications = (DomainNotificationHandler)notifications;
        }       

        public async Task<bool> Handle(RegisterNewLoanCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            else if (!_gameRepository.IsExistGames(request.GamesId))
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not create loan. Some informed games does not exist"));
                return false;
            }
            else
            {
                var newLoan = _Mapper.Map<Loan>(request);

                newLoan.LoanGames = (IList<LoanGame>)
                                    await _gameRepository.GetLoanGamesById(request.GamesId);

                await _loanRepository.Add(newLoan);

                return Commit();
            }
        }
    }
}