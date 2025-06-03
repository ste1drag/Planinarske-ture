using AutoMapper;
using Reviewing.Application.DTOs;
using Reviewing.Domain.Entities;

namespace Reviewing.Application.Mappings
{
    class UpdateReviewProfile : Profile
    {
        public UpdateReviewProfile()
        {
            // Map UpdateReviewDto to Review, updating existing Review object
            CreateMap<UpdateReviewDto, Review>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
