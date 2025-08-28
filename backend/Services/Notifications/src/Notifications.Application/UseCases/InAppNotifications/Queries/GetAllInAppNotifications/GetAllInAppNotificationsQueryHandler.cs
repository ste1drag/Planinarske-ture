using AutoMapper;
using MediatR;
using Notifications.Domain.Interfaces;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetAllInAppNotifications
{
    public class GetAllInAppNotificationsQueryHandler
        : IRequestHandler<GetAllInAppNotificationsQuery, IEnumerable<InAppNotificationResponse>>
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public GetAllInAppNotificationsQueryHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InAppNotificationResponse>> Handle(
            GetAllInAppNotificationsQuery request,
            CancellationToken cancellationToken
        )
        {
            var notifications = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InAppNotificationResponse>>(notifications);
        }
    }
}
