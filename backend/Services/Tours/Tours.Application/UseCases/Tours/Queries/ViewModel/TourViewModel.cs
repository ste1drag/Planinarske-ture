using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.UseCases.Tours.Commands.DTOs;
using Tours.Domain.Enums;

namespace Tours.Application.UseCases.Tours.Queries.ViewModel
{
    public class TourViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MountainId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TourStatusEnum Status { get; set; }
        public MountainWeatherEnum Weather { get; set; }
    }
}
