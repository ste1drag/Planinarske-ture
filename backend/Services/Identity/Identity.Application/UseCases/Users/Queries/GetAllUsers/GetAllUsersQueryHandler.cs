using AutoMapper;
using Identity.Application.Contracts;
using Identity.Application.DTOs;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDetailsDTO>>
    {
        private IAuthenticationService _authService;
        private IUserService _userService;
        private IRoleService _roleService;
        private IMapper _mapper;

        public GetAllUsersQueryHandler(IAuthenticationService authenticationService, IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _authService = authenticationService;
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;

        }

        public async Task<List<UserDetailsDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userService.Users.ToListAsync();

            return _mapper.Map<List<UserDetailsDTO>>(users);

        }
    }
}
