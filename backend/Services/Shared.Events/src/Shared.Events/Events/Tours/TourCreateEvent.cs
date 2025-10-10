namespace Shared.Events.Events.Tours;

public class TourCreateEvent
{
    public record TourCreatedEvent
    {
        public Guid Id { get; init; }
        public DateTime OccuredOn { get; init; }
        
        //DomainPayload
        public string TourId { get; init; }
        public string Title {get; init;}
        public string CreateByUserId {get; init;}
        
    }
}