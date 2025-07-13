using MediatR;
using Tours.Application.UseCases.Tours.Queries.ViewModel;

namespace Tours.Application.UseCases.Tours.Queries.GetListOfMountains
{
    public class GetListOfMountainsQuery : IRequest<List<MountainViewModel>>
    {
    }
}
