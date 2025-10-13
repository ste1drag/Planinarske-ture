using Reviewing.Application.DTOs;

namespace Reviewing.Application.Services
{
    public interface ITourService
    {
        Task<TourDto?> GetTourByIdAsync(Guid tourId);
    }
}
