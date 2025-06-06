using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Entities;

namespace Tours.Infrastructure
{
    public class SeedData
    {
        public static Mountain[] AddMountains()
        {
            return [
                new Mountain(){ Id = Guid.NewGuid(), Name = "Kopaonik", Height = 2017},
                new Mountain(){ Id = Guid.NewGuid(), Name = "Zlatibor", Height = 1492},
                new Mountain(){ Id = Guid.NewGuid(), Name = "Stara Planina", Height = 1544},
                new Mountain(){ Id = Guid.NewGuid(), Name = "Fruska Gora", Height = 539},
                new Mountain(){ Id = Guid.NewGuid(), Name = "Golija", Height = 1833},
                new Mountain(){ Id = Guid.NewGuid(), Name = "Rtanj", Height = 1565},
            ];
        }
    }
}
