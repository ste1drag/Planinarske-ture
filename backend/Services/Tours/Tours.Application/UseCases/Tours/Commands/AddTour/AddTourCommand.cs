using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.UseCases.Tours.Commands.DTOs;

namespace Tours.Application.UseCases.Tours.Commands.AddTour
{
    public class AddTourCommand : IRequest
    {
        public AddTourDTO addTourDTO;
    }
}
