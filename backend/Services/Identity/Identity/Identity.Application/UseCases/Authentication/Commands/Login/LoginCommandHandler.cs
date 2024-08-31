using Identity.Application.Contracts;
using Identity.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.Commands.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationModel>
    {
        IAuthenticationService _authService;
        public LoginCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task<AuthenticationModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authService.ValidateUser(request.userCredentialsDTO);
            if (user is null)
            {
                return null;
            }

            return await _authService.CreateAuthenticationModel(user);
        }
    }
}
