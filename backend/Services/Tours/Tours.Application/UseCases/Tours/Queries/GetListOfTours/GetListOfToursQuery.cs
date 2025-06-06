using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.UseCases.Tours.Queries.ViewModel;

namespace Tours.Application.UseCases.Tours.Queries.GetListOfTours
{
    public class GetListOfToursQuery : IRequest<List<TourViewModel>>
    {
    }
}
