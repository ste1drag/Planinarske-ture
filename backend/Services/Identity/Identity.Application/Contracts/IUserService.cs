using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contracts
{
    public interface IUserService
    {
        public IQueryable<User> Users { get; }
        public Task<User> FindNameByAsync(string username);
        public Task<User> FindByIdAsync(string userId);
        public Task<IResult> CreateAsync(User user, string password);
        public Task<IResult> AddToRoleAsync(User user, string role);
    }
}
