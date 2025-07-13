using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Commands.UpdateTourDescription
{
    public class UpdateTourDescriptionCommandHandler : IRequestHandler<UpdateTourDescriptionCommand>
    {
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;

        public UpdateTourDescriptionCommandHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTourDescriptionCommand request, CancellationToken cancellationToken)
        {
            Tour tour = await _toursRepository.GetById(request.TourId);
            tour.Description = request.Description;

            await _toursRepository.Update(tour);
        }
    }
}
