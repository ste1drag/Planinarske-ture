using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Domain.Entities
{
    public class Mountain 
    {
        #region Properties
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Height { get; set; }
        public List<Tour>? Tours { get; set; }
        #endregion
    }
}
