import { Mountain, TrendingUp, Star } from 'lucide-react';
import { useEffect, useState, useMemo } from 'react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import InfoBox from '@/components/ui/InfoBox';
import SearchBar from '@/components/ui/SearchBar';
import { useTranslation } from '@/contexts/TranslationContext';
import AddNewMountainDialog from '@/features/mountain/components/AddNewMountainDialog';
import MountainCard from '@/features/mountain/components/MountainCard';
import { useMountainStore } from '@/features/mountain/store/mountain-store';
import { TourStatus } from '@/features/tour/enums/TourStatus';
import { useTourStore } from '@/features/tour/store/tour-store';

const Mountains = () => {
  const t = useTranslation();
  const { mountains, isLoading, error, fetchMountains } = useMountainStore();
  const { tours, fetchAllTours } = useTourStore();
  const [searchQuery, setSearchQuery] = useState('');

  useEffect(() => {
    fetchMountains();
    fetchAllTours();
  }, [fetchMountains, fetchAllTours]);

  const filteredMountains = useMemo(() => {
    if (!searchQuery.trim()) {
      return mountains;
    }
    return mountains.filter(mountain =>
      mountain.name.toLowerCase().includes(searchQuery.toLowerCase())
    );
  }, [mountains, searchQuery]);

  const totalTours = useMemo(() => tours.length, [tours]);

  const upcomingTours = useMemo(() => {
    const now = new Date();
    return tours.filter(
      tour => tour.status === TourStatus.ACTIVE && new Date(tour.date) > now
    ).length;
  }, [tours]);

  return (
    <div className="flex flex-col gap-6">
      <HeaderTitle
        title={t.mountains}
        subTitle={t.mountainsSubTitle}
        button={<AddNewMountainDialog />}
      />
      <div className="flex flex-row gap-4">
        <InfoBox
          title={t.totalMountains}
          subTitle={mountains.length.toString()}
          icon={<Mountain className="text-forest" />}
        />
        <InfoBox
          title={t.totalTours}
          subTitle={totalTours.toString()}
          icon={<TrendingUp className="text-blue-600" />}
        />
        <InfoBox
          title={t.upcomingTours}
          subTitle={upcomingTours.toString()}
          icon={<Star className="text-yellow-500" />}
        />
      </div>
      <SearchBar
        placeholder={t.searchMountains}
        value={searchQuery}
        onChange={setSearchQuery}
      />

      {isLoading && (
        <div className="text-center py-8 text-gray-500">
          Loading mountains...
        </div>
      )}

      {error && (
        <div className="text-center py-8 text-red-500">Error: {error}</div>
      )}

      {!isLoading && !error && filteredMountains.length === 0 && (
        <div className="text-center py-8 text-gray-500">
          No mountains found matching `{searchQuery}`
        </div>
      )}

      {!isLoading && !error && filteredMountains.length > 0 && (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-3">
          {filteredMountains.map(mountain => (
            <MountainCard key={mountain.id} mountain={mountain} />
          ))}
        </div>
      )}
    </div>
  );
};

export default Mountains;
