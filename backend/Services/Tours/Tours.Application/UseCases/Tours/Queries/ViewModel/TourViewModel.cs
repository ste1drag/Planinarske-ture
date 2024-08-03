using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.UseCases.Tours.Queries.ViewModel
{
    public class TourViewModel
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string Description { get; set; }
        public DateTime TourDate { get; set; }
    }
}
