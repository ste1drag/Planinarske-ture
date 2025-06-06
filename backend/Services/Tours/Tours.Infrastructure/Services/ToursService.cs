using Microsoft.EntityFrameworkCore;
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
        public ToursService(ToursDbContext dbContext) : base(dbContext) { }

        public async Task<List<Tour>> GetToursByMountainId(Guid mountainId)
        {
            var results = await _dbContext.Tours.Where(x => x.MountainId == mountainId).ToListAsync();

            return results;
        }
    }
}
