using AutoMapper;
using Reviewing.Application.DTOs;
using Reviewing.Domain.Entities;
using Reviewing.Domain.Enums;
using Reviewing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewing.Application.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score != null ? src.Score.Value : default))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty.HasValue ? (int)src.Difficulty.Value : default));

            CreateMap<ReviewDto, Review>()
            .ConstructUsing(src => new Review(
                src.UserId,
                src.TourId,
                src.Title,
                src.Comment,
                src.Difficulty.HasValue ? (Difficulty)src.Difficulty.Value : default,
                src.Score.HasValue ? new Score(src.Score.Value) : null,
                src.Id,
                src.CreatedDate,
                src.UpdatedDate
            ));
        }
    }
}
