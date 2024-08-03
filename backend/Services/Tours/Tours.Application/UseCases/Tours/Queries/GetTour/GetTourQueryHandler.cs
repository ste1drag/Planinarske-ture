using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Application.UseCases.Tours.Queries.GetListOfTours;
using Tours.Application.UseCases.Tours.Queries.ViewModel;

namespace Tours.Application.UseCases.Tours.Queries.GetTour
{
    public class GetTourQueryHandler : IRequestHandler<GetTourQuery, TourViewModel>
    {
        private readonly IToursRepository _toursRepository;
        public readonly IMapper _mapper;

        public GetTourQueryHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public async Task<TourViewModel> Handle(GetTourQuery request, CancellationToken cancellationToken)
        {
            var toursList = await _toursRepository.GetById(request.TourId);

            return _mapper.Map<TourViewModel>(toursList);
        }
    }
}
