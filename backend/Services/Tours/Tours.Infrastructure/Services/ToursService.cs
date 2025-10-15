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

        public async Task<TourEnrollment> GetEnrollmentAsync(Guid tourId, string userId)
        {
            return await _dbContext.TourEnrollments
                .FirstOrDefaultAsync(e => e.TourId == tourId && e.UserId == userId);
        }

        public async Task<TourEnrollment> AddEnrollmentAsync(TourEnrollment enrollment)
        {
            await _dbContext.TourEnrollments.AddAsync(enrollment);
            await _dbContext.SaveChangesAsync();
            return enrollment;
        }

        public async Task RemoveEnrollmentAsync(TourEnrollment enrollment)
        {
            _dbContext.TourEnrollments.Remove(enrollment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetEnrollmentCountAsync(Guid tourId)
        {
            return await _dbContext.TourEnrollments.CountAsync(e => e.TourId == tourId);
        }

        public async Task<bool> IsUserEnrolledAsync(Guid tourId, string userId)
        {
            return await _dbContext.TourEnrollments
                .AnyAsync(e => e.TourId == tourId && e.UserId == userId);
        }
    }
}
