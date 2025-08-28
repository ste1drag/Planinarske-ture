using AutoMapper;
using MediatR;
using Notifications.Domain.Interfaces;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByUserId
{
    public class GetInAppNotificationsByUserIdQueryHandler
        : IRequestHandler<
            GetInAppNotificationsByUserIdQuery,
            IEnumerable<InAppNotificationResponse>
        >
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public GetInAppNotificationsByUserIdQueryHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InAppNotificationResponse>> Handle(
            GetInAppNotificationsByUserIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var notifications = await _repository.GetByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<InAppNotificationResponse>>(notifications);
        }
    }
}
