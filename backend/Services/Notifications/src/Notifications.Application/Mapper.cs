using AutoMapper;
using Notifications.Domain.Entities;
using Notifications.Application.DTOs;

namespace Notifications.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<InAppNotification, InAppNotificationResponse>().ReverseMap();

            CreateMap<CreateInAppNotificationRequest, InAppNotification>()
                .ConstructUsing(src => new InAppNotification(
                    src.Type,
                    src.TourId,
                    src.Name ?? "Untitled Tour",
                    src.DateOfTour,
                    src.MountainName ?? "Unknown Mountain",
                    src.Description ?? string.Empty,
                    src.MinNumberOfPeople,
                    src.MaxNumberOfPeople
                )
                {
                    TourId = src.TourId // Explicitly set required property
                });

            CreateMap<UpdateInAppNotificationRequest, InAppNotification>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ReadAt, opt => opt.Ignore())
                .ForMember(dest => dest.TourId, opt => opt.Ignore());
        }
    }
}