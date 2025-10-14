using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Application.Contracts;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

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
            // Normalize username first
            user.UserName = _userManager.NormalizeName(user.UserName);
            user.NormalizedUserName = user.UserName;
            user.NormalizedEmail = _userManager.NormalizeEmail(user.Email);

            // Check if user already exists
            var existingUser = await _userManager.FindByNameAsync(user.UserName);
            if (existingUser != null)
            {
                var result = IdentityResult.Failed(new IdentityError { Code = "DuplicateUserName", Description = $"Username '{user.UserName}' is already taken." });
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new Exception(errors);
            }

            // Try to create the user
            var createResult = await _userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join("; ", createResult.Errors.Select(e => e.Description));
                throw new Exception(errors);
            }

            // Return success
            return new ResultWrapper(createResult);
        }

        public async Task<User> FindNameByAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

    }
}
