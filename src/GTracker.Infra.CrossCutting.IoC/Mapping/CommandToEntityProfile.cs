using AutoMapper;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.EntityModel;

namespace GTracker.Infra.CrossCutting.IoC.Mapping
{
    public class CommandToEntityProfile : Profile
    {
        public CommandToEntityProfile()
        {
             CreateMap<RegisterNewFriendCommand, Friend>();
             CreateMap<UpdateFriendCommand, Friend>();
        }
    }
}