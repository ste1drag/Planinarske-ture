import { Sun, Cloud, CloudRain } from 'lucide-react';

export enum Weather {
  SUNNY,
  CLOUDY,
  RAINY,
}

export const WeatherColoring: Record<Weather, string> = {
  [Weather.SUNNY]: '#FFD700',
  [Weather.CLOUDY]: '#C0C0C0',
  [Weather.RAINY]: '#1E90FF',
};

export const WeatherIcons = {
  [Weather.SUNNY]: Sun,
  [Weather.CLOUDY]: Cloud,
  [Weather.RAINY]: CloudRain,
};
