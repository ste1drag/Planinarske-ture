using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Contracts;
using Tours.Application.Repositories;
using Tours.Application.UseCases.Tours.Queries.GetListOfTours;
using Tours.Application.UseCases.Tours.Queries.ViewModel;

namespace Tours.Application.UseCases.Tours.Queries.GetListOfMountains
{
    public class GetListOfMountainsQueryHandler : IRequestHandler<GetListOfMountainsQuery, List<MountainViewModel>>
    {
        private readonly IMountainRepository _mountainRepository;
        public readonly IMapper _mapper;

        public GetListOfMountainsQueryHandler(IMountainRepository mountainRepository, IMapper mapper)
        {
            _mountainRepository = mountainRepository;
            _mapper = mapper;
        }

        public async Task<List<MountainViewModel>> Handle(GetListOfMountainsQuery request, CancellationToken cancellationToken)
        {
            var mountainList = await _mountainRepository.GetAll();

            return _mapper.Map<List<MountainViewModel>>(mountainList);
        }
    }
}
