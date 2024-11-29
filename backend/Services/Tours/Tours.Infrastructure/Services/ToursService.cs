using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Domain.Entities;

namespace Tours.Infrastructure.Services
{
    public class ToursService : BaseService<Tour>, IToursRepository
    {
    }
}
