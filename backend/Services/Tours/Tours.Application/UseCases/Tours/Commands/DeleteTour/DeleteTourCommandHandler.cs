using AutoMapper;
using MediatR;
using Tours.Application.Repositories;
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Commands.DeleteTour
{
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand>
    {

        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;

        public DeleteTourCommandHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            Tour tour = await _toursRepository.GetById(request.TourId);

            await _toursRepository.Delete(tour);
        }
    }
}
