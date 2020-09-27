using AutoMapper;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Commands.Game;
using GTracker.Domain.EntityModel;

namespace GTracker.Infra.CrossCutting.IoC.Mapping
{
    public class CommandToEntityProfile : Profile
    {
        public CommandToEntityProfile()
        {   
            // Friend
             CreateMap<RegisterNewFriendCommand, Friend>();
             CreateMap<UpdateFriendCommand, Friend>();

             //Game
             CreateMap<RegisterNewGameCommand, Game>();
             CreateMap<UpdateGameCommand, Game>();
        }
    }
}