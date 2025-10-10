import { Calendar } from 'lucide-react';
import StatusBadge from './StatusBadge';
import WeatherBadge from './WeatherBadge';
import { TourViewModel } from '../types/TourDto';
import { Button } from '@/components/ui/Button';
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/Card';
import IconPrefixedText from '@/components/ui/IconPrefixedText';
import { useTranslation } from '@/contexts/TranslationContext';

export default function TourCard({ tour }: { tour: TourViewModel }) {
  const t = useTranslation();

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      weekday: 'short',
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    };
    return date.toLocaleDateString('en-US', options);
  };

  return (
    <Card className="w-full h-full flex flex-col">
      <CardHeader className="flex justify-between items-start">
        <StatusBadge tourStatus={tour.status} />
        <WeatherBadge weather={tour.weather} />
      </CardHeader>
      <CardContent className="flex-grow flex flex-col">
        <div>
          <CardTitle className="pb-3">{tour.name}</CardTitle>
          <hr />
          <p className="pt-3">{tour.description}</p>
        </div>
        <IconPrefixedText
          icon={Calendar}
          text={formatDate(tour.date)}
          className="mt-auto pt-2"
        />
      </CardContent>
      <CardFooter className="flex justify-center mt-auto">
        <Button className="flex w-full">{t.joinTour}</Button>
      </CardFooter>
    </Card>
  );
}
