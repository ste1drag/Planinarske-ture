using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.UseCases.Tours.Commands.DTOs
{
    public class AddTourDTO
    {
        public string Name { get; set; }
        public Guid MountainId { get; set; }
        public string Description { get; set; }
        public int MinNumberOfPeople { get; init; }
        public int MaxNumberOfPeople { get; init; }
        public DateTime Date { get; set; }
    }
}
