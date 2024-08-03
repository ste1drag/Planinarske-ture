using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Repositories;
using Tours.Application.UseCases.Tours.Queries.ViewModel;


namespace Tours.Application.UseCases.Tours.Queries.GetListOfTours
{
    public class GetListOfToursQueryHandler : IRequestHandler<GetListOfToursQuery, List<TourViewModel>>
    {
        private readonly IToursRepository _toursRepository;
        public readonly IMapper _mapper;

        public GetListOfToursQueryHandler(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public async Task<List<TourViewModel>> Handle(GetListOfToursQuery request, CancellationToken cancellationToken)
        {
            var toursList = await _toursRepository.GetAll();

            return _mapper.Map<List<TourViewModel>>(toursList);
        }
    }
}
