import { Mountain, TrendingUp, Star } from 'lucide-react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import InfoBox from '@/components/ui/InfoBox';
import SearchBar from '@/components/ui/SearchBar';
import { useTranslation } from '@/contexts/TranslationContext';
import AddNewMountainDialog from '@/features/mountain/components/AddNewMountainDialog';

const Mountains = () => {
  const t = useTranslation();

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
          subTitle="TODO - number"
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
    </div>
  );
};

export default Mountains;
