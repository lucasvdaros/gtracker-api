using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Core.Interface;
using GTracker.Domain.Core.Notification;
using GTracker.Domain.EntityModel;
using GTracker.Domain.Interface.Repository;
using MediatR;

namespace GTracker.Domain.CommandHandler
{
    public class FriendCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewFriendCommand, bool>,
        IRequestHandler<UpdateFriendCommand, bool>
    {

        private readonly IMediatorHandler _Bus;
        private readonly IMapper _Mapper;
        private readonly IFriendRepository _friendRepository;
        private readonly DomainNotificationHandler _notifications;

        public FriendCommandHandler(IUnitOfWork uow,
            IMediatorHandler bus,
            IMapper mapper,
            IFriendRepository friendRepository,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _Bus = bus;
            _Mapper = mapper;
            _friendRepository = friendRepository;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task<bool> Handle(RegisterNewFriendCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            else
            {
                var newFriend = _Mapper.Map<Friend>(request);
                _friendRepository.Add(newFriend);

                if (Commit())
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
        }

        public async Task<bool> Handle(UpdateFriendCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            else if (!_friendRepository.IsExistFriend(request.Id))
            {
                await _Bus.RaiseEvent(new DomainNotification(request.MessageType,
                        "Could not update friend. The informed Id friend does not exist"));
                return false;
            }
            else
            {
                var friend = await _friendRepository.GetById(request.Id);
                _Mapper.Map<UpdateFriendCommand, Friend>(request, friend);

                _friendRepository.Update(friend);

                return Commit();
            }
        }
    }
}