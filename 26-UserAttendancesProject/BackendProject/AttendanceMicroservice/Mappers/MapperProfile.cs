using AttendanceMicroservice.DataTransferObject;
using AttendanceMicroservice.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<AttendanceCreation, Attendance>()
                .ForMember(dest => dest.Start, org => org.MapFrom( e => DateTime.Parse(e.Start)))
                .ForMember(dest => dest.End, org => org.MapFrom( e => DateTime.Parse(e.End)));
            this.CreateMap<Attendance, AttendanceResponse>();
        }
    }
}
