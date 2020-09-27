using AutoMapper;
using GTracker.Domain.DTO.User;
using GTracker.Domain.EntityModel;

namespace GTracker.Infra.CrossCutting.IoC.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
             CreateMap<User, UserDTO>();
        }
    }
}