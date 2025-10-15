using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tours.Application.Common.Exceptions;
using Tours.Application.Repositories;
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Commands.JoinTour
{
    public class JoinTourCommandHandler : IRequestHandler<JoinTourCommand>
    {
        private readonly IToursRepository _toursRepository;

        public JoinTourCommandHandler(IToursRepository toursRepository)
        {
            _toursRepository = toursRepository;
        }

        public async Task Handle(JoinTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _toursRepository.GetById(request.TourId);
            if (tour == null)
            {
                throw new NotFoundException(nameof(Tour), request.TourId);
            }

            var existingEnrollment = await _toursRepository.IsUserEnrolledAsync(request.TourId, request.UserId);
            if (existingEnrollment)
            {
                throw new ValidationException(new[] { ("Enrollment", "You are already enrolled in this tour") });
            }

            if (!tour.CanJoin())
            {
                throw new ValidationException(new[] { ("Tour", "Tour is full or not available for enrollment") });
            }

            var enrollment = new TourEnrollment(request.TourId, request.UserId);
            await _toursRepository.AddEnrollmentAsync(enrollment);

            tour.IncrementEnrollment();
            await _toursRepository.Update(tour);
        }
    }
}
