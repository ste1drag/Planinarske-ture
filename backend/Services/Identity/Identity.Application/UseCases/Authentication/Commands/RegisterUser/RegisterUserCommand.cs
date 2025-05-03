using Identity.Application.DTOs;
using MediatR;

namespace Identity.Application.UseCases.Authentication.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest
    {
        public NewUserDTO userDTO;
    }
}
