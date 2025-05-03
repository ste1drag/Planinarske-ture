using AutoMapper;
using Identity.Application.Contracts;
using Identity.Application.UseCases.Authentication.Commands.RegisterAdministrator;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private IAuthenticationService _authService;
        private IUserService _userService;
        private IRoleService _roleService;
        private IMapper _mapper;

        public RegisterUserCommandHandler(IAuthenticationService authenticationService, IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _authService = authenticationService;
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request.userDTO);

            IResult result = await _userService.CreateAsync(user, request.userDTO.Password);

            if (!result.Succeeded)
            {
                return;
            }

            await _userService.AddToRoleAsync(user, Roles.User);
        }
    }
}
