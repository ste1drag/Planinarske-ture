import GenericBadge from '@/components/ui/GenericCardBadge';
import {
  Weather,
  WeatherColoring,
  WeatherIcons,
} from '@/features/mountain/enums/weather';

interface WeatherBadgeProps {
  weather: Weather;
}

export default function WeatherBadge({ weather }: WeatherBadgeProps) {
  return (
    <GenericBadge
      value={weather}
      label={Weather[weather]}
      colorMap={WeatherColoring}
      iconMap={WeatherIcons}
    />
  );
}
