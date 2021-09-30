using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.DataTransferObject;
using UserMicroservice.Entities;

namespace UserMicroservice.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<UserCreation, User>()
                .ForMember(dest => dest.BirthDate, org => org.MapFrom(e => DateTime.Parse(e.BirthDate)));
            this.CreateMap<User, UserResponse>();
            this.CreateMap<Credentials, User>()
                .ForMember(dest => dest.Nickname, org => org.MapFrom(e => e.Username))
                .ForMember(dest => dest.Password, org => org.MapFrom(e => e.Password));
        }
    }
}
