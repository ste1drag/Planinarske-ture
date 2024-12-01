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
        public void MappingTours()
        {
            CreateMap<Mountain, MountainDTO>().ReverseMap();
            CreateMap<AddTourDTO, Tour>().ReverseMap();
            CreateMap<Mountain, MountainViewModel>().ReverseMap();
            CreateMap<Tour, TourViewModel>().ReverseMap();
        }
    }
}
