using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GTracker.Domain.Commands.Game;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.Core.Notification;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;
using MediatR;

namespace GTracker.Domain.CommandHandler
{
    public class GameCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewGameCommand, bool>,
        IRequestHandler<UpdateGameCommand, bool>
    {
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _Mapper;
        private readonly IGameRepository _gameRepository;
        private readonly DomainNotificationHandler _notifications;

        public GameCommandHandler(IUnitOfWork uow,
                                IMediatorHandler bus,
                                IMapper mapper,
                                IGameRepository gameRepository,
                                INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _Bus = bus;
            _Mapper = mapper;
            _gameRepository = gameRepository;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task<bool> Handle(RegisterNewGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            else
            {
                var newGame = _Mapper.Map<Game>(request);
                _gameRepository.Add(newGame);

                if (Commit())
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
        }

        public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            else if (!_gameRepository.IsExistGame(request.Id))
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not update game. The informed Id game does not exist"));
                return false;
            }
            else
            {
                var game = await _gameRepository.GetById(request.Id);
                _Mapper.Map<UpdateGameCommand, Game>(request, game);

                _gameRepository.Update(game);

                return Commit();
            }
        }
    }
}