using Identity.Application.Contracts;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.UseCases.Users.Commands.AssignTourGuideRole
{
    public class AssignTourGuideRoleCommandHandler : IRequestHandler<AssignTourGuideRoleCommand>
    {
        private readonly IUserService _userService;

        public AssignTourGuideRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(AssignTourGuideRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.FindByIdAsync(request.UserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _userService.AddToRoleAsync(user, Roles.TourGuide);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to assign TourGuide role to user");
            }
        }
    }
}
