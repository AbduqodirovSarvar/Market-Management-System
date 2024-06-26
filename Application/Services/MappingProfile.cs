using Application.Models.ViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Enum, EnumViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => Convert.ToInt32(z)))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.ToString()));
        }
    }
}
