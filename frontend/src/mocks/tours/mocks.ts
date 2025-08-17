import { Weather } from '../../features/mountains/enums/weather';
import { TourStatus } from '../../features/tour/enums/tour-status';
import { TourViewModel } from '../../features/tour/types/tour-dto';

export const tourMocks: TourViewModel[] = [
  {
    id: '123e4567-e89b-12d3-a456-426614174001',
    name: 'Kopaonik Winter Adventure',
    mountainId: '550e8400-e29b-41d4-a716-446655440001', // Kopaonik
    description:
      'Experience the winter beauty of Kopaonik with snowshoeing and winter hiking trails.',
    date: '2024-12-15T09:00:00Z',
    status: TourStatus.ACTIVE,
    weather: Weather.SUNNY,
  },
  {
    id: '123e4567-e89b-12d3-a456-426614174002',
    name: 'Zlatibor Nature Walk',
    mountainId: '550e8400-e29b-41d4-a716-446655440002', // Zlatibor
    description:
      "Peaceful nature walk through Zlatibor's rolling hills and meadows.",
    date: '2024-11-20T08:30:00Z',
    status: TourStatus.RESERVED,
    weather: Weather.CLOUDY,
  },
  {
    id: '123e4567-e89b-12d3-a456-426614174003',
    name: 'Tara River Canyon Explorer',
    mountainId: '550e8400-e29b-41d4-a716-446655440003', // Tara
    description:
      'Explore the magnificent Tara River Canyon and surrounding wilderness.',
    date: '2024-10-25T07:00:00Z',
    status: TourStatus.CANCELED,
    weather: Weather.RAINY,
  },
  {
    id: '123e4567-e89b-12d3-a456-426614174004',
    name: 'Durmitor Peak Challenge',
    mountainId: '550e8400-e29b-41d4-a716-446655440004', // Durmitor
    description:
      "Challenging hike to Durmitor's highest peaks for experienced hikers.",
    date: '2025-01-10T06:00:00Z',
    status: TourStatus.ACTIVE,
    weather: Weather.SUNNY,
  },
  {
    id: '123e4567-e89b-12d3-a456-426614174005',
    name: 'Fruška Gora Wine & Hike',
    mountainId: '550e8400-e29b-41d4-a716-446655440005', // Fruška Gora
    description:
      'Combine hiking with wine tasting in the beautiful Fruška Gora region.',
    date: '2024-12-01T10:00:00Z',
    status: TourStatus.ACTIVE,
    weather: Weather.CLOUDY,
  },
];

// Helper to generate new ID
export const generateTourId = () => {
  return `123e4567-e89b-12d3-a456-${Date.now().toString().slice(-12)}`;
};
