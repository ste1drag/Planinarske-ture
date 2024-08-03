using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Enums;

namespace Tours.Domain.Entities
{
    public class Tour
    {
        public Guid TourId { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int MinNumberOfPeople { get; set; }
        public int MaxNumberOfPeople { get; set; }
        public int CurrentNumberOfPeople { get; set; }
        public string Description { get; set; }
        public DateTime TourDate { get; set; }
        public TourStatusEnum Status { get; set; }
    }
}
