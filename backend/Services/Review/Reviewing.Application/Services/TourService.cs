using Microsoft.Extensions.Logging;
using Reviewing.Application.DTOs;
using System.Text.Json;

namespace Reviewing.Application.Services
{
    public class TourService : ITourService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TourService> _logger;

        public TourService(HttpClient httpClient, ILogger<TourService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<TourDto?> GetTourByIdAsync(Guid tourId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"tours-api/Tours/{tourId}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to fetch tour {TourId}. Status: {StatusCode}", tourId, response.StatusCode);
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var tour = JsonSerializer.Deserialize<TourDto>(content, options);
                return tour;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching tour {TourId}", tourId);
                return null;
            }
        }
    }
}
