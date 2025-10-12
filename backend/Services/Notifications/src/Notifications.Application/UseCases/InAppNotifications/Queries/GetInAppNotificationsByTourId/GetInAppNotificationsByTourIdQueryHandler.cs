using AutoMapper;
using MediatR;
using Notifications.Application.Contracts;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByTourId
{
    public class GetInAppNotificationsByTourIdQueryHandler
        : IRequestHandler<
            GetInAppNotificationsByTourIdQuery,
            IEnumerable<InAppNotificationResponse>
        >
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public GetInAppNotificationsByTourIdQueryHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InAppNotificationResponse>> Handle(
            GetInAppNotificationsByTourIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var notifications = await _repository.GetByTourIdAsync(request.TourId);
            return _mapper.Map<IEnumerable<InAppNotificationResponse>>(notifications);
        }
    }
}