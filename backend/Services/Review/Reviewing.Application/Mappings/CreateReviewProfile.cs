using AutoMapper;
using Reviewing.Application.DTOs;
using Reviewing.Domain.Entities;

namespace Reviewing.Application.Mappings
{
    public class CreateReviewProfile : Profile
    {
        public CreateReviewProfile()
        {
            CreateMap<CreateReviewDto, Review>();
        }
    }
}
