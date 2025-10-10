import { Calendar, Mountain, Star, Users } from 'lucide-react';
import { useEffect, useMemo } from 'react';
import InfoBox from '../ui/InfoBox';
import { useTranslation } from '@/contexts/TranslationContext';
import { useMountainStore } from '@/features/mountain/store/mountain-store';
import { TourStatus } from '@/features/tour/enums/TourStatus';
import { useTourStore } from '@/features/tour/store/tour-store';

export default function AppStats() {
  const t = useTranslation();
  const { mountains, fetchMountains } = useMountainStore();
  const { tours, fetchAllTours } = useTourStore();

  useEffect(() => {
    fetchMountains();
    fetchAllTours();
  }, [fetchMountains, fetchAllTours]);

  const activeTours = useMemo(() => {
    return tours.filter(tour => tour.status === TourStatus.ACTIVE).length;
  }, [tours]);

  return (
    <div className="flex py-[2vh]">
      <InfoBox
        title={activeTours.toString()}
        subTitle={t.activeTours}
        icon={<Calendar className="text-blue-600" />}
      />
      <InfoBox
        title={mountains.length.toString()}
        subTitle={t.mountains}
        icon={<Mountain className="text-forest" />}
      />
      <InfoBox
        title="TODO - NUMBER"
        subTitle={t.happyHikers}
        icon={<Users className="text-green-600" />}
      />
      <InfoBox
        title="TODO - NUMBER"
        subTitle={t.avgRating}
        icon={<Star className="text-yellow-500" />}
      />
    </div>
  );
}
