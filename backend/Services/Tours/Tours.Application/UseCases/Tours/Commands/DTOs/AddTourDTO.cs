using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.UseCases.Tours.Commands.DTOs
{
    public class AddTourDTO
    {
        public string TourName { get; set; }
        public MountainDTO Mountain { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
