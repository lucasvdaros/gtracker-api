using AutoMapper;
using GTracker.Domain.Commands.User;
using GTracker.Domain.DTO.User;

namespace GTracker.Infra.CrossCutting.IoC.Mapping
{
    public class DtoToCommandProfile : Profile
    {
        public DtoToCommandProfile()
        {
            CreateMap<LoginUserDTO, LoginUserCommand>();
        }
    }
}