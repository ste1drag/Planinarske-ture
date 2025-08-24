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

  return (
    <Card className="w-full min-w-[30vw] max-w-[40vw] min-h-fit">
      <CardHeader className="flex justify-between items-start">
        <StatusBadge tourStatus={tour.status} />
        <WeatherBadge weather={tour.weather} />
      </CardHeader>
      <CardContent>
        <CardTitle className="pb-3">{tour.name}</CardTitle>
        <hr />
        <p className="pt-3">{tour.description}</p>
        <IconPrefixedText icon={Calendar} text={tour.date} className="pt-2" />
      </CardContent>
      <CardFooter className="flex justify-center">
        <Button className="flex w-full">{t.joinTour}</Button>
      </CardFooter>
    </Card>
  );
}
