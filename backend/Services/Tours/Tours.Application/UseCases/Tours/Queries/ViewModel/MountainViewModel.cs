using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.UseCases.Tours.Commands.DTOs;

namespace Tours.Application.UseCases.Tours.Queries.ViewModel
{
    public class MountainViewModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Height { get; set; }
    }
}
