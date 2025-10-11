using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.Events.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Application.UseCases.Tours.Commands.DTOs;
using Tours.Domain.Entities;
using Tours.Domain.ValueObjects;

namespace Tours.Application.UseCases.Tours.Commands.AddTour
{
    public class AddTourCommandHandler : IRequestHandler<AddTourCommand>
    {
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddTourCommandHandler(IToursRepository toursRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(AddTourCommand request, CancellationToken cancellationToken)
        {
            Tour tour = _mapper.Map<Tour>(request.AddTourDTO);
            tour.HikerRange = new HikerRange(request.AddTourDTO.MinNumberOfPeople, request.AddTourDTO.MaxNumberOfPeople);
            await _toursRepository.AddNew(tour);

            var tourCreatedEvent = new TourCreateEvent.TourCreatedEvent
            {
                Id = Guid.NewGuid(),
                OccuredOn = DateTime.UtcNow,
                TourId = tour.Id.ToString(),
                Name = tour.Name,
                Description = tour.Description,
                DateOfTour = tour.Date,
                MountainId = tour.MountainId.ToString()

            };

            await _publishEndpoint.Publish(tourCreatedEvent, cancellationToken);


        }
    }
}
