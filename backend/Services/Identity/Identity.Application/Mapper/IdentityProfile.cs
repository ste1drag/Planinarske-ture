using AutoMapper;
using Identity.Application.DTOs;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Mapper
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<User, NewUserDTO>().ReverseMap();
            CreateMap<User, UserDetailsDTO>().ReverseMap();
        }
    }
}
