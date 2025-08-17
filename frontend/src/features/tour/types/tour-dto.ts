import { Weather } from '../../mountains/enums/weather';
import { TourStatus } from '../enums/tour-status';

export interface TourViewModel {
  id: string;
  name: string;
  mountainId: string;
  description: string;
  date: string;
  status: TourStatus;
  weather: Weather;
}
