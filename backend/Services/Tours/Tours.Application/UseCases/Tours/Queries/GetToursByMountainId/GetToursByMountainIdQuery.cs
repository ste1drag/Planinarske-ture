using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.UseCases.Tours.Queries.ViewModel;

namespace Tours.Application.UseCases.Tours.Queries.GetToursByMountainId
{
    public class GetToursByMountainIdQuery : IRequest<List<TourViewModel>>
    {
        public Guid MountainId { get; set; }
    }
}
