using AutoMapper;
using Shop.Api.ViewModels.User;
using Shop.Application.Users.AddAdress;

namespace Shop.Api.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddUserAddressCommand, AddAddressViewModel>().ReverseMap();
        }
    }
}
