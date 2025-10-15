using MediatR;
using System;

namespace Tours.Application.UseCases.Tours.Commands.JoinTour
{
    public class JoinTourCommand : IRequest
    {
        public Guid TourId { get; set; }
        public string UserId { get; set; }
    }
}
