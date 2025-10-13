using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tours.Domain.Enums;
using Microsoft.Extensions.Hosting;
using Tours.Application.Repositories;

namespace Tours.Application.BackgroundServices
{
    public class TourStatusUpdateService : BackgroundService
    {
        private readonly ILogger<TourStatusUpdateService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromHours(1); // Run every hour

        public TourStatusUpdateService(
            ILogger<TourStatusUpdateService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Tour Status Update Service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await UpdatePastTourStatusesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while updating tour statuses.");
                }

                await Task.Delay(_interval, stoppingToken);
            }
            _logger.LogInformation("Tour Status Update Service is stopping.");
        }

        private async Task UpdatePastTourStatusesAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var tourRepository = scope.ServiceProvider.GetRequiredService<IToursRepository>();

            _logger.LogInformation("Checking for past tours to mark as completed...");

            var tours = await tourRepository.GetAll();
            var now = DateTime.UtcNow;
            var updatedCount = 0;

            foreach (var tour in tours)
            {
                // Only update tours that are not already COMPLETED or CANCELED
                // and whose date has passed
                if (tour.Date < now &&
                    tour.Status != TourStatusEnum.COMPLETED &&
                    tour.Status != TourStatusEnum.CANCELED)
                {
                    tour.Status = TourStatusEnum.COMPLETED;
                    await tourRepository.Update(tour);
                    updatedCount++;
                    _logger.LogInformation("Tour {TourId} ({TourName}) marked as COMPLETED", tour.Id, tour.Name);
                }
            }

            if (updatedCount > 0)
            {
                _logger.LogInformation("Updated {Count} tours to COMPLETED status", updatedCount);
            }
            else
            {
                _logger.LogInformation("No tours needed status update");
            }
        }
    }
}
