import { Status } from '../enums/status';
import { Weather } from '../enums/weather';

export interface Tour {
  id: string;
  name: string;
  hikerRange: number;
  description: string;
  date: Date;
  status: Status;
  mountainId: string;
  weather: Weather;
}
