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
                .ConstructUsing(src => new InAppNotification(src.UserId, src.Type, src.Content));
            CreateMap<UpdateInAppNotificationRequest, InAppNotification>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
