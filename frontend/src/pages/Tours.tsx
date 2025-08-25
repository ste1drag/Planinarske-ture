import { Plus } from 'lucide-react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import SearchBar from '@/components/ui/SearchBar';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/Select';
import { useTranslation } from '@/contexts/TranslationContext';
import { TourStatus } from '@/features/tour/enums/TourStatus';

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
      <div className="flex justify-between items-center">
        <SearchBar containerClassName="flex-1" placeholder={t.searchTours} />
        <Select>
          <SelectTrigger className="w-[180px]">
            <SelectValue placeholder={t.selectStatus} />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value={TourStatus.ACTIVE}>{t.active}</SelectItem>
            <SelectItem value={TourStatus.RESERVED}>{t.reserved}</SelectItem>
            <SelectItem value={TourStatus.CANCELED}>{t.canceled}</SelectItem>
          </SelectContent>
        </Select>
      </div>
    </div>
  );
};

export default Tours;
