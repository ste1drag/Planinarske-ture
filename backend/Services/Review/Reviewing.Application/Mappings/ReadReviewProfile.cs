using AutoMapper;
using Reviewing.Application.DTOs;
using Reviewing.Domain.Entities;

namespace Reviewing.Application.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReadReviewDto>()
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score != null ? src.Score.Value : default))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty.HasValue ? (int)src.Difficulty.Value : default));
        }
    }
}
