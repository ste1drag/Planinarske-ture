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
        Task<List<Tour>> GetToursByMountainId(Guid mountainId);
        Task<TourEnrollment> GetEnrollmentAsync(Guid tourId, string userId);
        Task<TourEnrollment> AddEnrollmentAsync(TourEnrollment enrollment);
        Task RemoveEnrollmentAsync(TourEnrollment enrollment);
        Task<int> GetEnrollmentCountAsync(Guid tourId);
        Task<bool> IsUserEnrolledAsync(Guid tourId, string userId);
    }
}
