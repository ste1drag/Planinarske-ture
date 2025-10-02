import { Mountain, TrendingUp, Star } from 'lucide-react';
import { useEffect } from 'react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import InfoBox from '@/components/ui/InfoBox';
import SearchBar from '@/components/ui/SearchBar';
import { useTranslation } from '@/contexts/TranslationContext';
import AddNewMountainDialog from '@/features/mountain/components/AddNewMountainDialog';
import MountainCard from '@/features/mountain/components/MountainCard';
import { useMountainStore } from '@/features/mountain/store/mountain-store';

const Mountains = () => {
  const t = useTranslation();
  const { mountains, isLoading, error, fetchMountains } = useMountainStore();

  useEffect(() => {
    fetchMountains();
  }, [fetchMountains]);

  return (
    <div className="flex flex-col">
      <HeaderTitle
        title={t.mountains}
        subTitle={t.mountainsSubTitle}
        button={<AddNewMountainDialog />}
      />
      <div className="flex flex-row">
        <InfoBox
          title={t.totalMountains}
          subTitle={mountains.length.toString()}
          icon={<Mountain className="text-forest" />}
        />
        <InfoBox
          title={t.totalTours}
          subTitle="TODO - number"
          icon={<TrendingUp className="text-blue-600" />}
        />
        <InfoBox
          title={t.upcomingTours}
          subTitle="TODO - number"
          icon={<Star className="text-yellow-500" />}
        />
      </div>
      <SearchBar placeholder={t.searchMountains} />

      <div className="p-4 flex flex-wrap gap-4">
        {isLoading && <p>Loading mountains...</p>}
        {error && <p className="text-red-600">Error: {error}</p>}
        {!isLoading &&
          !error &&
          mountains.map(mountain => (
            <MountainCard key={mountain.id} mountain={mountain} />
          ))}
      </div>
    </div>
  );
};

export default Mountains;
