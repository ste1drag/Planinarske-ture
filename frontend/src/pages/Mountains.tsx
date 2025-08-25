import { Mountain, Plus, TrendingUp } from 'lucide-react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import InfoBox from '@/components/ui/InfoBox';
import SearchBar from '@/components/ui/SearchBar';
import { useTranslation } from '@/contexts/TranslationContext';

const Mountains = () => {
  const t = useTranslation();

  const addMountainButton = (
    <button className="bg-forest-light text-white font-bold py-2 px-4 rounded flex items-center gap-2">
      <Plus size={16} />
      {t.addMountainButton}
    </button>
  );

  return (
    <div className="flex flex-col">
      <HeaderTitle
        title={t.mountains}
        subTitle={t.mountainsSubTitle}
        button={addMountainButton}
      />
      <div className="flex flex-row">
        <InfoBox
          title={t.totalMountains}
          subTitle="TODO - number"
          icon={<Mountain />}
        />
        <InfoBox
          title={t.totalTours}
          subTitle="TODO - number"
          icon={<TrendingUp />}
        />
        <InfoBox
          title={t.upcomingTours}
          subTitle="TODO - number"
          icon={<TrendingUp />}
        />
      </div>
      <SearchBar placeholder={t.searchMountains} />
    </div>
  );
};

export default Mountains;
