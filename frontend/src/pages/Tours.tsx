import { useEffect, useState } from 'react';
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
import AddNewTourDialog from '@/features/tour/components/AddNewTourDialog';
import TourCard from '@/features/tour/components/TourCard';
import { TourStatus } from '@/features/tour/enums/TourStatus';
import { useTourStore } from '@/features/tour/store/tour-store';

const Tours = () => {
  const t = useTranslation();
  const { tours, isLoading, error, fetchAllTours } = useTourStore();
  const [searchQuery, setSearchQuery] = useState('');
  const [statusFilter, setStatusFilter] = useState<string | undefined>();

  useEffect(() => {
    fetchAllTours();
  }, [fetchAllTours]);

  const filteredTours = tours.filter(tour => {
    const matchesSearch = tour.name
      .toLowerCase()
      .includes(searchQuery.toLowerCase());
    const matchesStatus = statusFilter
      ? tour.status.toString() === statusFilter
      : true;
    return matchesSearch && matchesStatus;
  });

  return (
    <div className="flex flex-col gap-6">
      <HeaderTitle
        title={t.tours}
        subTitle={t.tourPageTitle}
        button={<AddNewTourDialog />}
      />
      <div className="flex justify-between items-center gap-4">
        <SearchBar
          containerClassName="flex-1"
          placeholder={t.searchTours}
          value={searchQuery}
          onChange={setSearchQuery}
        />
        <Select value={statusFilter} onValueChange={setStatusFilter}>
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

      {isLoading && (
        <div className="text-center py-8 text-gray-500">{t.loading}</div>
      )}

      {error && (
        <div className="text-center py-8 text-red-500">
          {t.error}: {error}
        </div>
      )}

      {!isLoading && !error && filteredTours.length === 0 && (
        <div className="text-center py-8 text-gray-500">{t.noToursFound}</div>
      )}

      {!isLoading && !error && filteredTours.length > 0 && (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {filteredTours.map(tour => (
            <TourCard key={tour.id} tour={tour} />
          ))}
        </div>
      )}
    </div>
  );
};

export default Tours;
