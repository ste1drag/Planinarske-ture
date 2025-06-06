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
using Tours.Domain.Entities;

namespace Tours.Application.UseCases.Tours.Queries.GetToursByMountainId
{
    public class GetToursByMountainIdQueryHandler : IRequestHandler<GetToursByMountainIdQuery, List<TourViewModel>>
    {
        private readonly IToursRepository _toursRepository;
        public readonly IMapper _mapper;

        public GetToursByMountainIdQueryHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }
        public async Task<List<TourViewModel>> Handle(GetToursByMountainIdQuery request, CancellationToken cancellationToken)
        {
            var tourList = await _toursRepository.GetToursByMountainId(request.MountainId);

            return _mapper.Map<List<Tour>, List<TourViewModel>>(tourList);
        }
    }
}
