﻿using System;
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
        #region Properties
        public Guid Id { get; init; }
        public string Name { get; set; }
        public HikerRange? HikerRange { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TourStatusEnum Status { get; set; }
        public Guid MountainId { get; set; }
        public Mountain Mountain { get; init; }
        public MountainWeatherEnum Weather { get; set; }
        #endregion 
    }
}
