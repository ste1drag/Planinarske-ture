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
        public string CreatedBy { get; set; }
        #endregion

        #region Domain Methods
        public bool CanJoin()
        {
            if (Status == TourStatusEnum.CANCELED)
                return false;

            if (Status == TourStatusEnum.COMPLETED)
                return false;

            if (HikerRange == null)
                return false;

            return HikerRange.NumberOfRegisteredPeople < HikerRange.MaxNumberOfPeople;
        }

        public void IncrementEnrollment()
        {
            if (HikerRange == null)
                throw new InvalidOperationException("HikerRange is not initialized");

            if (!CanJoin())
                throw new InvalidOperationException("Tour is full or not available for enrollment");

            HikerRange = HikerRange with { NumberOfRegisteredPeople = HikerRange.NumberOfRegisteredPeople + 1 };
        }

        public void DecrementEnrollment()
        {
            if (HikerRange == null)
                throw new InvalidOperationException("HikerRange is not initialized");

            if (HikerRange.NumberOfRegisteredPeople > 0)
            {
                HikerRange = HikerRange with { NumberOfRegisteredPeople = HikerRange.NumberOfRegisteredPeople - 1 };
            }
        }

        public void CancelTour()
        {
            if (Status == TourStatusEnum.COMPLETED)
                throw new InvalidOperationException("Cannot cancel a completed tour");

            Status = TourStatusEnum.CANCELED;
        }
        #endregion
    }
}
