using Identity.Application.Contracts;
using Identity.Application.DTOs;
using Identity.Application.UseCases.Authentication.Commands.Logout;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.Commands.Refresh
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, AuthenticationModel>
    {
        private IAuthenticationService _authService;
        private IUserService _userService;
        private IRoleService _roleService;

        public RefreshCommandHandler(IAuthenticationService authenticationService, IUserService userService, IRoleService roleService)
        {
            _authService = authenticationService;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<AuthenticationModel> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            User user = await _userService.FindNameByAsync(request.refreshTokenCredentials.UserName);

            if (user is null)
                return null;

            RefreshToken refreshToken = user.RefreshTokens.FirstOrDefault(r => r.Token == request.refreshTokenCredentials.RefreshToken);

            if (refreshToken is null)
                return null;

            if (refreshToken.ExpiryTime < DateTime.Now)
                return null;

            return await _authService.CreateAuthenticationModel(user);

        }
    }
}
