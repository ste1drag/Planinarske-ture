import { Status } from '../enums/status';
import { Weather } from '../enums/weather';
import { Tour } from '../types/tour';

export const mockTours: Tour[] = [
  {
    id: '550e8400-e29b-41d4-a716-446655440001',
    name: 'Sunrise Hike to Kopaonik Peak',
    hikerRange: 15,
    description:
      'Experience breathtaking sunrise views from the highest peak of Kopaonik National Park. This moderate hike offers stunning panoramic views of the surrounding valleys.',
    date: new Date('2025-09-15T06:00:00'),
    status: Status.ACTIVE,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440001',
    weather: Weather.SUNNY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440002',
    name: 'Tara River Canyon Adventure',
    hikerRange: 12,
    description:
      "Explore Europe's deepest canyon with this challenging trek along the Tara River. Perfect for experienced hikers seeking adventure and natural beauty.",
    date: new Date('2025-09-22T08:30:00'),
    status: Status.ACTIVE,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440002',
    weather: Weather.CLOUDY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440003',
    name: 'Durmitor National Park Trail',
    hikerRange: 20,
    description:
      'Discover the rugged beauty of Durmitor with glacial lakes, limestone peaks, and diverse wildlife. A full-day hiking experience for nature enthusiasts.',
    date: new Date('2025-10-05T07:00:00'),
    status: Status.RESERVED,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440003',
    weather: Weather.SUNNY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440004',
    name: 'Fruška Gora Wine Trail Hike',
    hikerRange: 25,
    description:
      "Combine hiking with wine tasting on this unique tour through Fruška Gora's vineyards and monasteries. Easy trail suitable for all fitness levels.",
    date: new Date('2025-08-28T09:00:00'),
    status: Status.CANCELED,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440004',
    weather: Weather.RAINY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440005',
    name: 'Zlatibor Mountain Ridge Walk',
    hikerRange: 18,
    description:
      'Gentle mountain ridge walking with spectacular views over Zlatibor plateau. Features traditional mountain villages and local cuisine stops.',
    date: new Date('2025-09-30T08:00:00'),
    status: Status.ACTIVE,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440005',
    weather: Weather.SUNNY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440006',
    name: 'Rtanj Pyramid Mystery Hike',
    hikerRange: 16,
    description:
      "Uncover the mysteries of Serbia's pyramid-shaped mountain. This moderate hike combines natural beauty with local legends and folklore.",
    date: new Date('2025-10-12T07:30:00'),
    status: Status.ACTIVE,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440006',
    weather: Weather.CLOUDY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440007',
    name: 'Stara Planina Border Trail',
    hikerRange: 14,
    description:
      'Trek along the Serbian-Bulgarian border through pristine wilderness. Challenging terrain with rewarding views of two countries.',
    date: new Date('2025-11-02T08:00:00'),
    status: Status.RESERVED,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440007',
    weather: Weather.RAINY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440008',
    name: 'Avala Tower Hill Climb',
    hikerRange: 30,
    description:
      "Easy family-friendly hike to Belgrade's iconic Avala Tower. Perfect for beginners with historical sites and city views included.",
    date: new Date('2025-09-08T10:00:00'),
    status: Status.ACTIVE,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440008',
    weather: Weather.SUNNY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440009',
    name: 'Prokletije Wild Mountain Trek',
    hikerRange: 10,
    description:
      "Extreme hiking adventure in the 'Accursed Mountains'. Only for very experienced hikers seeking the ultimate challenge in untouched wilderness.",
    date: new Date('2025-10-20T06:30:00'),
    status: Status.ACTIVE,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440009',
    weather: Weather.CLOUDY,
  },
  {
    id: '550e8400-e29b-41d4-a716-446655440010',
    name: 'Šar Mountains Alpine Adventure',
    hikerRange: 22,
    description:
      'Multi-day alpine hiking experience through Kosovo and North Macedonia border region. Includes mountain huts and traditional Balkan cuisine.',
    date: new Date('2025-11-15T07:00:00'),
    status: Status.RESERVED,
    mountainId: 'm-550e8400-e29b-41d4-a716-446655440010',
    weather: Weather.SUNNY,
  },
];
