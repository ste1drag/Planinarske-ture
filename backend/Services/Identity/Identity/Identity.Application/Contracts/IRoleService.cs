using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contracts
{
    public interface IRoleService
    {
        public Task<bool> RoleExistsAsync(Roles role);
    }
}
