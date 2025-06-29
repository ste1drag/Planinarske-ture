using Microsoft.AspNetCore.Mvc;
using Notifications.Domain.Interfaces;
using Notifications.Domain.Entities;
using Presentation.DTOs;

namespace Notifications.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InAppNotificationsController : ControllerBase
    {
        private readonly IInAppNotificationRepository _repository;

        public InAppNotificationsController(IInAppNotificationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InAppNotificationResponse>>> GetAll()
        {
            var notifications = await _repository.GetAllAsync();
            var response = notifications.Select(MapToResponse);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InAppNotificationResponse>> GetById(string id)
        {
            var notification = await _repository.GetByIdAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(MapToResponse(notification));
        }

        [HttpPost]
        public async Task<ActionResult<InAppNotificationResponse>> Create(
            CreateInAppNotificationRequest request
        )
        {
            var notification = new InAppNotification(request.UserId, request.Type, request.Content);
            var created = await _repository.CreateAsync(notification);
            var response = MapToResponse(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        private static InAppNotificationResponse MapToResponse(InAppNotification notification)
        {
            return new InAppNotificationResponse
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Type = notification.Type,
                Content = notification.Content,
                Status = notification.Status,
                CreatedAt = notification.CreatedAt,
                ReadAt = notification.ReadAt,
            };
        }
    }
}
