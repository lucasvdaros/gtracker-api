using System.Linq;
using AutoMapper;
using GTracker.Domain.DTO.Friend;
using GTracker.Domain.DTO.Game;
using GTracker.Domain.DTO.Loan;
using GTracker.Domain.DTO.User;
using GTracker.Domain.EntityModel;

namespace GTracker.Infra.CrossCutting.IoC.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<Friend, FriendDTO>();

            CreateMap<Game, GameDTO>()
                .ForMember(g => g.Status, opts =>
                    opts.MapFrom(g => g.LoanGames.Select(lg => lg.LoanStatus)))
                .ForMember(g => g.DataTerminoEmprestimo, opts =>
                    opts.MapFrom(g => g.LoanGames.Select(lg => lg.DataEnd)));

            CreateMap<Loan, LoanDTO>()
                .ForMember(l => l.Games, opts =>
                    opts.MapFrom(g => g.LoanGames.Select(gg => gg.Game)));
        }
    }
}