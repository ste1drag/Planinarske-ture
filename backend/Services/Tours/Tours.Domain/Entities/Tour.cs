using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Enums;
using Tours.Domain.ValueObjects;

namespace Tours.Domain.Entities
{
    public class Tour
    {
        public Guid TourId { get; init; }
        public string Name { get; set; }
        public HikerRange HikerRange { get; set; }
        public string Description { get; set; }
        public DateTime TourDate { get; set; }
        public TourStatusEnum Status { get; set; }
        public Mountain Mountain { get; init; }
    }
}
