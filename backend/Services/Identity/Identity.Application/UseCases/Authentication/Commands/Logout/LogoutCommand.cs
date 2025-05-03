using Identity.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.Commands.Logout
{
    public class LogoutCommand : IRequest
    {
        public RefreshTokenModel refreshTokenModel;
    }
}
