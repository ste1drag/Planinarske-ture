import { Plus } from 'lucide-react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import SearchBar from '@/components/ui/SearchBar';
import { useTranslation } from '@/contexts/TranslationContext';

const Tours = () => {
  const t = useTranslation();

  const addTourButton = (
    <button className="bg-forest-light text-white font-bold py-2 px-4 rounded flex items-center gap-2">
      <Plus size={16} />
      {t.addTourButton}
    </button>
  );

  return (
    <div className="flex flex-col">
      <HeaderTitle
        title={t.tours}
        subTitle={t.tourPageTitle}
        button={addTourButton}
      />
      <SearchBar placeholder={t.searchTours} />
    </div>
  );
};

export default Tours;
