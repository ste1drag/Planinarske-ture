using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.UseCases.Tours.Commands.DTOs;
using Tours.Application.UseCases.Tours.Queries.ViewModel;
using Tours.Domain.Entities;

namespace Tours.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddTourDTO, Tour>().ReverseMap();
            CreateMap<Mountain, MountainViewModel>().ReverseMap();
            CreateMap<Tour, TourViewModel>()
                .ForMember(dest => dest.MinNumberOfPeople, opt => opt.MapFrom(src => src.HikerRange != null ? src.HikerRange.MinNumberOfPeople : 0))
                .ForMember(dest => dest.MaxNumberOfPeople, opt => opt.MapFrom(src => src.HikerRange != null ? src.HikerRange.MaxNumberOfPeople : 0))
                .ForMember(dest => dest.NumberOfRegisteredPeople, opt => opt.MapFrom(src => src.HikerRange != null ? src.HikerRange.NumberOfRegisteredPeople : 0))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ReverseMap();
        }
    }
}
