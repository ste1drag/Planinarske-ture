using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Enums;

namespace Tours.Domain.Entities
{
    public class Mountain 
    {
        #region Properties
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Height { get; init; }
        public List<Tour> Tours { get; } = new List<Tour>();
        public MountainWeatherEnum Weather { get; set; }
        #endregion
    }
}
