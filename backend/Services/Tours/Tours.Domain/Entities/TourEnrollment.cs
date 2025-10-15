using System;

namespace Tours.Domain.Entities
{
    public class TourEnrollment
    {
        public Guid Id { get; init; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
        public string UserId { get; set; }
        public DateTime EnrolledAt { get; set; }

        public TourEnrollment()
        {
            Id = Guid.NewGuid();
            EnrolledAt = DateTime.UtcNow;
        }

        public TourEnrollment(Guid tourId, string userId)
        {
            Id = Guid.NewGuid();
            TourId = tourId;
            UserId = userId;
            EnrolledAt = DateTime.UtcNow;
        }
    }
}
