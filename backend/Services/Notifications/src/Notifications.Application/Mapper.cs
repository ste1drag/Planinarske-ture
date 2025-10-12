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
                    "system",
                    src.Type,
                    src.Name ?? "Untitled",
                    $"Tour '{src.Name}' scheduled for {src.DateOfTour:yyyy-MM-dd}",
                    src.Description ?? string.Empty
                ))
                .ForMember(dest => dest.RelatedEntityId, opt => opt.MapFrom(src => src.TourId))
                .ForMember(dest => dest.RelatedEntityType, opt => opt.MapFrom(src => "Tour"));

            CreateMap<UpdateInAppNotificationRequest, InAppNotification>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MountainId, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ReadAt, opt => opt.Ignore())
                .ForMember(dest => dest.RelatedEntityId, opt => opt.Ignore())
                .ForMember(dest => dest.RelatedEntityType, opt => opt.Ignore());
        }
    }
}