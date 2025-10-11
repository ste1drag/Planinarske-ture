namespace Shared.Events.Events.Tours;

public class TourCreateEvent
{
    public record TourCreatedEvent
    {
        public Guid Id { get; init; }
        public DateTime OccuredOn { get; init; }

        //DomainPayload
        public required string TourId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public DateTime DateOfTour { get; init; }
        public string? MountainId { get; init; }
    }
}