using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.UseCases.Tours.Commands.UpdateTourReservations
{
    public class UpdateTourReservationsCommand : IRequest
    {
        public Guid TourId { get; set; }
    }
}
