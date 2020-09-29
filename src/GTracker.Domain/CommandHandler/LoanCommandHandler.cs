using System;
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
        IRequestHandler<RegisterNewLoanCommand, bool>,
        IRequestHandler<FinishLoanCommand, bool>
    {
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _Mapper;
        private readonly ILoanRepository _loanRepository;
        private readonly IGameRepository _gameRepository;
        private readonly ILoanGameRepository _loanGameRepository;
        private readonly DomainNotificationHandler _notifications;

        public LoanCommandHandler(IUnitOfWork uow,
                                IMediatorHandler bus,
                                IMapper mapper,
                                ILoanRepository loanRepository,
                                IGameRepository gameRepository,
                                ILoanGameRepository loanGameRepository,
                                INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _Bus = bus;
            _Mapper = mapper;
            _loanRepository = loanRepository;
            _gameRepository = gameRepository;
            _loanGameRepository = loanGameRepository;
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
            else if ((_loanGameRepository.NotAvailableGames(request.GamesId).Count) != 0)
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not create loan. Some informed games are borrowed to someone"));
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

        public async Task<bool> Handle(FinishLoanCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            else if (!_gameRepository.IsExistGame(request.GameId))
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not finish loan. The informed games does not exist"));
                return false;
            }
            else if (!_loanGameRepository.BelongToLoan(request.LoanId, request.GameId))
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not finish loan. The informed game does not belong to this loan"));
                return false;
            }            
            else if (!_loanGameRepository.IsBorrowedGame(request.GameId))
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not finish loan. The informed game is not borrowed"));
                return false;
            }
            else
            {
                var loanGame =
                    await _loanGameRepository.getByIds(request.LoanId, request.GameId);

                loanGame.LoanStatus = (int)StatusLoanEnum.RETURNED;
                loanGame.DataEnd = DateTime.Now;

                _loanGameRepository.Update(loanGame);

                return Commit();
            }
        }
    }
}