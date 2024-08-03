using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Application.UseCases.Tours.Commands.DTOs
{
    public class AddTourDTO
    {
        public string TourName;
        public int Height;
        public int MaxNumberOfPeople;
        public int MinNumberOfPeople;
        public string Description;
        public DateTime Date;
    }
}
