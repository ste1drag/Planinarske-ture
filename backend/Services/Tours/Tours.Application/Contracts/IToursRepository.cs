using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Contracts;
using Tours.Domain.Entities;

namespace Tours.Application.Repositories
{
    public interface IToursRepository : IAsyncRepository<Tour>
    {
    }
}
