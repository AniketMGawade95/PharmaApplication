using AutoMapper;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;

namespace PharmaAPICreation.Mapper
{
    public class MappingData:Profile
    {
        
        public MappingData()
        {
            CreateMap<User, LoginResponseDTO>().ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }

        
    }
}
