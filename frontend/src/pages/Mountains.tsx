import { Plus } from 'lucide-react';
import HeaderTitle from '@/components/layout/HeaderTitle';
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
    <div className="flex">
      <HeaderTitle
        title={t.mountains}
        subTitle={t.mountainsSubTitle}
        button={addMountainButton}
      />
    </div>
  );
};

export default Mountains;
