using AutoMapper;
using GymManager.Core.DTOs.Users;

namespace GymManager.Core.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Entities.Client, ClientDto>().ReverseMap();
        }
    }
}