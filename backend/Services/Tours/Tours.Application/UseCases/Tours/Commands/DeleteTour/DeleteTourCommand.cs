using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.UseCases.Tours.Commands.DeleteTour
{
    public class DeleteTourCommand : IRequest
    {
        public string TourId { get; set; }
    }
}
