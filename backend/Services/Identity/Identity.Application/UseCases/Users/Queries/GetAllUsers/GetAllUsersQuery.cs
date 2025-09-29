using Identity.Application.DTOs;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDetailsDTO>>
    {
        
    }
}
