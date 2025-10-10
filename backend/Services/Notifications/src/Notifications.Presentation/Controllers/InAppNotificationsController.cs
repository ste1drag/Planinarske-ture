using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifications.Application.DTOs;
using Notifications.Application.UseCases.InAppNotifications.Commands.CreateInAppNotification;
using Notifications.Application.UseCases.InAppNotifications.Commands.DeleteInAppNotification;
using Notifications.Application.UseCases.InAppNotifications.Commands.UpdateInAppNotification;
using Notifications.Application.UseCases.InAppNotifications.Queries.GetAllInAppNotifications;
using Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotification;
using Notifications.Application.UseCases.InAppNotifications.Queries.GetInAppNotificationsByUserId;

namespace Notifications.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InAppNotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InAppNotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InAppNotificationResponse>>> GetAll()
        {
            var query = new GetAllInAppNotificationsQuery();
            var notifications = await _mediator.Send(query);
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InAppNotificationResponse>> GetById(string id)
        {
            var query = new GetInAppNotificationQuery { Id = id };
            var notification = await _mediator.Send(query);

            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        [HttpPost]
        public async Task<ActionResult<InAppNotificationResponse>> Create(
            CreateInAppNotificationRequest request)
        {
            var command = new CreateInAppNotificationCommand(request);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<InAppNotificationResponse>>> GetByUserId(
            string userId
        )
        {
            var query = new GetInAppNotificationsByUserIdQuery { UserId = userId };
            var notifications = await _mediator.Send(query);
            return Ok(notifications);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InAppNotificationResponse>> Update(
            string id,
            UpdateInAppNotificationRequest request
        )
        {
            var command = new UpdateInAppNotificationCommand { Id = id, Request = request };
            var response = await _mediator.Send(command);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeleteInAppNotificationCommand { Id = id };
            var success = await _mediator.Send(command);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
