using Identity.Application.Contracts;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private IAuthenticationService _authService;
        private IUserService _userService;
        private IRoleService _roleService;

        public LogoutCommandHandler(IAuthenticationService authenticationService, IUserService userService, IRoleService roleService)
        {
            _authService = authenticationService;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            User user = await _userService.FindNameByAsync(request.refreshTokenModel.UserName);
            if(user is null)
            {
                return;
            }

            await _authService.RemoveRefreshToken(user, request.refreshTokenModel.RefreshToken);
        }
    }
}
