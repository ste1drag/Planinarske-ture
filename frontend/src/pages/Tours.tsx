import { Plus } from 'lucide-react';
import HeaderTitle from '@/components/layout/HeaderTitle';
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
    <div className="flex">
      <HeaderTitle
        title={t.tours}
        subTitle={t.tourPageTitle}
        button={addTourButton}
      />
    </div>
  );
};

export default Tours;
