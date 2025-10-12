using AutoMapper;
using MediatR;
using Notifications.Application.Contracts;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByMountainId
{
    public class GetInAppNotificationsByMountainIdQueryHandler
        : IRequestHandler<
            GetInAppNotificationsByMountainIdQuery,
            IEnumerable<InAppNotificationResponse>
        >
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public GetInAppNotificationsByMountainIdQueryHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InAppNotificationResponse>> Handle(
            GetInAppNotificationsByMountainIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var notifications = await _repository.GetByMountainIdAsync(request.MountainId);
            return _mapper.Map<IEnumerable<InAppNotificationResponse>>(notifications);
        }
    }
}