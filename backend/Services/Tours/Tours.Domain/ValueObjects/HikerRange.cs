using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Domain.ValueObjects
{
    public record HikerRange
    {
        #region Properties
        public int MinNumberOfPeople { get; init; }
        public int MaxNumberOfPeople { get; init; }
        public int NumberOfRegisteredPeople { get; set; }
        #endregion

        #region Constructors
        public HikerRange(int minNumberOfPeople, int maxNumberOfPeople)
        {
            if (minNumberOfPeople > maxNumberOfPeople)
                throw new ArgumentOutOfRangeException("Minimal number of people is bigger than maximum number of people");

            MinNumberOfPeople = minNumberOfPeople;
            MaxNumberOfPeople = maxNumberOfPeople;
            NumberOfRegisteredPeople = 0;
        }

        public HikerRange(int minNumberOfPeople, int maxNumberOfPeople, int numberOfRegisteredPeople)
        {
            if (minNumberOfPeople > maxNumberOfPeople)
                throw new ArgumentOutOfRangeException("Minimal number of people is bigger than maximum number of people");

            if (numberOfRegisteredPeople > maxNumberOfPeople)
                throw new ArgumentOutOfRangeException("Number of registered people exceeds maximum capacity");

            if (numberOfRegisteredPeople < 0)
                throw new ArgumentOutOfRangeException("Number of registered people cannot be negative");

            MinNumberOfPeople = minNumberOfPeople;
            MaxNumberOfPeople = maxNumberOfPeople;
            NumberOfRegisteredPeople = numberOfRegisteredPeople;
        }
        #endregion
    }
}
