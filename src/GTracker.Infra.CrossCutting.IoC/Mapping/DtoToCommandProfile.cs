using AutoMapper;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Commands.Game;
using GTracker.Domain.Commands.Loan;
using GTracker.Domain.Commands.User;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.DTO.Game;
using GTracker.Domain.DTO.Loan;
using GTracker.Domain.DTO.User;

namespace GTracker.Infra.CrossCutting.IoC.Mapping
{
    public class DtoToCommandProfile : Profile
    {
        public DtoToCommandProfile()
        {
            // User
            CreateMap<LoginUserDTO, LoginUserCommand>();

            // Friend
            CreateMap<CreateFriendDTO, RegisterNewFriendCommand>();
            CreateMap<UpdateFriendDTO, UpdateFriendCommand>();

            // Game
            CreateMap<CreateGameDTO, RegisterNewGameCommand>();
            CreateMap<UpdateGameDTO, UpdateGameCommand>();

            // Loan
            CreateMap<CreateLoanDTO, RegisterNewLoanCommand>();
            CreateMap<FinishLoanDTO, FinishLoanCommand>();
        }
    }
}