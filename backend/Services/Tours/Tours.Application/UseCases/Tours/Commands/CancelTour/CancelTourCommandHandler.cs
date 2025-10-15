using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tours.Application.Common.Exceptions;
using Tours.Application.Repositories;
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Commands.CancelTour
{
    public class CancelTourCommandHandler : IRequestHandler<CancelTourCommand>
    {
        private readonly IToursRepository _toursRepository;

        public CancelTourCommandHandler(IToursRepository toursRepository)
        {
            _toursRepository = toursRepository;
        }

        public async Task Handle(CancelTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _toursRepository.GetById(request.TourId);
            if (tour == null)
            {
                throw new NotFoundException(nameof(Tour), request.TourId);
            }

            // Validate that the user is the creator of the tour
            if (tour.CreatedBy != request.UserId)
            {
                throw new ValidationException(new[] { ("Authorization", "You can only cancel tours that you created") });
            }

            // Cancel the tour (status change)
            tour.CancelTour();

            await _toursRepository.Update(tour);
        }
    }
}
