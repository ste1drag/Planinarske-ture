using MediatR;
using System;

namespace Tours.Application.UseCases.Tours.Commands.CancelTour
{
    public class CancelTourCommand : IRequest
    {
        public Guid TourId { get; set; }
        public string UserId { get; set; }
    }
}
