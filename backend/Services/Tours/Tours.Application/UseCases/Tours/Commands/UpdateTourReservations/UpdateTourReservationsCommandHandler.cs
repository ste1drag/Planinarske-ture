using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Commands.UpdateTourReservations
{
    public class UpdateTourReservationsCommandHandler : IRequestHandler<UpdateTourReservationsCommand>
    {
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;

        public UpdateTourReservationsCommandHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTourReservationsCommand request, CancellationToken cancellationToken)
        {
            Tour tour = await _toursRepository.GetById(request.TourId);
            int newNumberOfReservations = tour.HikerRange.NumberOfRegisteredPeople + 1;
            if (newNumberOfReservations > tour.HikerRange.MaxNumberOfPeople)
            {
                throw new ArgumentOutOfRangeException("Tour participants is already full");
            }
            tour.HikerRange.NumberOfRegisteredPeople = newNumberOfReservations;

            await _toursRepository.Update(tour);
        }
    }
}
