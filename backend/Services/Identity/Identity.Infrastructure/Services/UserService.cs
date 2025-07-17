using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Application.Contracts;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IQueryable<User> Users => _userManager.Users;

        public async Task<IResult> AddToRoleAsync(User user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            return new ResultWrapper(result);
        }

        public async Task<IResult> CreateAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return new ResultWrapper(result);
        }

        public async Task<User> FindNameByAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

    }
}
