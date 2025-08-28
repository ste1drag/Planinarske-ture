using AutoMapper;
using MediatR;
using Notifications.Domain.Interfaces;
using Notifications.Application.DTOs;

namespace Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotification
{
    public class GetInAppNotificationQueryHandler
        : IRequestHandler<GetInAppNotificationQuery, InAppNotificationResponse?>
    {
        private readonly IInAppNotificationRepository _repository;
        private readonly IMapper _mapper;

        public GetInAppNotificationQueryHandler(
            IInAppNotificationRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InAppNotificationResponse?> Handle(
            GetInAppNotificationQuery request,
            CancellationToken cancellationToken
        )
        {
            var notification = await _repository.GetByIdAsync(request.Id);
            if (notification == null)
                return null;

            return _mapper.Map<InAppNotificationResponse>(notification);
        }
    }
}
