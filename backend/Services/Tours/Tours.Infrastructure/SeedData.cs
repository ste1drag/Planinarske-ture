using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Entities;
using Tours.Domain.Enums;
using Tours.Domain.ValueObjects;

namespace Tours.Infrastructure
{
    public class SeedData
    {
        // Static mountain IDs for consistent reference
        public static readonly Guid KopaonikId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid ZlatiborId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        public static readonly Guid StaraPlaninaId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        public static readonly Guid FruskaGoraId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        public static readonly Guid GolijaId = Guid.Parse("55555555-5555-5555-5555-555555555555");
        public static readonly Guid RtanjId = Guid.Parse("66666666-6666-6666-6666-666666666666");

        // Static tour IDs for review reference
        public static readonly Guid PastTour1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        public static readonly Guid PastTour2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        public static readonly Guid PastTour3Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        public static readonly Guid PastTour4Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

        public static Mountain[] AddMountains()
        {
            return [
                new Mountain(){ Id = KopaonikId, Name = "Kopaonik", Height = 2017},
                new Mountain(){ Id = ZlatiborId, Name = "Zlatibor", Height = 1492},
                new Mountain(){ Id = StaraPlaninaId, Name = "Stara Planina", Height = 1544},
                new Mountain(){ Id = FruskaGoraId, Name = "Fruska Gora", Height = 539},
                new Mountain(){ Id = GolijaId, Name = "Golija", Height = 1833},
                new Mountain(){ Id = RtanjId, Name = "Rtanj", Height = 1565},
            ];
        }

        public static Tour[] AddTours()
        {
            var now = DateTime.UtcNow;

            return [
                // Past tours (for reviews)
                new Tour()
                {
                    Id = PastTour1Id,
                    Name = "Kopaonik Summit Adventure",
                    Description = "A challenging hike to the highest peak of Kopaonik with breathtaking views of central Serbia. Experience the beauty of alpine meadows and pristine nature.",
                    Date = now.AddDays(-30), // 30 days ago
                    Status = TourStatusEnum.COMPLETED,
                    MountainId = KopaonikId,
                    Weather = MountainWeatherEnum.SUNNY,
                    HikerRange = new HikerRange(5, 15, 12)
                },
                new Tour()
                {
                    Id = PastTour2Id,
                    Name = "Zlatibor Nature Trail",
                    Description = "Easy walking tour through the beautiful meadows and forests of Zlatibor. Perfect for families and beginners.",
                    Date = now.AddDays(-15), // 15 days ago
                    Status = TourStatusEnum.COMPLETED,
                    MountainId = ZlatiborId,
                    Weather = MountainWeatherEnum.CLOUDY,
                    HikerRange = new HikerRange(8, 25, 20)
                },
                new Tour()
                {
                    Id = PastTour3Id,
                    Name = "Stara Planina Waterfalls Tour",
                    Description = "Explore the stunning waterfalls and gorges of Stara Planina. Moderate difficulty with amazing photo opportunities.",
                    Date = now.AddDays(-7), // 7 days ago
                    Status = TourStatusEnum.COMPLETED,
                    MountainId = StaraPlaninaId,
                    Weather = MountainWeatherEnum.RAINY,
                    HikerRange = new HikerRange(6, 18, 15)
                },
                new Tour()
                {
                    Id = PastTour4Id,
                    Name = "Fruska Gora Monastery Circuit",
                    Description = "Cultural and nature tour visiting historic monasteries nestled in Fruska Gora. Easy terrain suitable for all ages.",
                    Date = now.AddDays(-3), // 3 days ago
                    Status = TourStatusEnum.COMPLETED,
                    MountainId = FruskaGoraId,
                    Weather = MountainWeatherEnum.SUNNY,
                    HikerRange = new HikerRange(10, 30, 25)
                },

                // Active/Future tours
                new Tour()
                {
                    Id = Guid.NewGuid(),
                    Name = "Golija Autumn Colors",
                    Description = "Witness the spectacular autumn colors on Golija mountain. Moderate hiking with stops at shepherd settlements.",
                    Date = now.AddDays(7), // 7 days from now
                    Status = TourStatusEnum.ACTIVE,
                    MountainId = GolijaId,
                    Weather = MountainWeatherEnum.SUNNY,
                    HikerRange = new HikerRange(8, 20, 5)
                },
                new Tour()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rtanj Mystical Pyramid",
                    Description = "Explore the mysterious pyramid-shaped Rtanj mountain. Legend says it has special energy fields. Challenging hike.",
                    Date = now.AddDays(14), // 14 days from now
                    Status = TourStatusEnum.ACTIVE,
                    MountainId = RtanjId,
                    Weather = MountainWeatherEnum.SUNNY,
                    HikerRange = new HikerRange(5, 12, 3)
                },
                new Tour()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kopaonik Winter Preparation",
                    Description = "Early winter tour to prepare the trails for ski season. Includes snowshoe training.",
                    Date = now.AddDays(30), // 30 days from now
                    Status = TourStatusEnum.ACTIVE,
                    MountainId = KopaonikId,
                    Weather = MountainWeatherEnum.SNOWY,
                    HikerRange = new HikerRange(6, 15, 0)
                },
                new Tour()
                {
                    Id = Guid.NewGuid(),
                    Name = "Zlatibor Spring Festival Hike",
                    Description = "Join us for a celebratory spring hike with traditional music and food at the summit.",
                    Date = now.AddDays(45), // 45 days from now
                    Status = TourStatusEnum.RESERVED,
                    MountainId = ZlatiborId,
                    Weather = MountainWeatherEnum.SUNNY,
                    HikerRange = new HikerRange(10, 40, 40)
                }
            ];
        }
    }
}
