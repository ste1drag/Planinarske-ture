using Identity.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<AuthenticationModel>
    {
        public UserCredentialsDTO userCredentialsDTO;
    }
}
