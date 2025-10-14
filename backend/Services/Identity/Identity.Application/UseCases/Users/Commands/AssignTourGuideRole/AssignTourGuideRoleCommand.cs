using MediatR;

namespace Identity.Application.UseCases.Users.Commands.AssignTourGuideRole
{
    public class AssignTourGuideRoleCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
