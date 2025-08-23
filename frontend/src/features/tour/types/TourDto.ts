import { TourStatus } from '../enums/TourStatus';
import { Weather } from '@/features/mountains/enums/weather';

export interface TourViewModel {
  id: string;
  name: string;
  mountainId: string;
  description: string;
  date: string;
  status: TourStatus;
  weather: Weather;
}
