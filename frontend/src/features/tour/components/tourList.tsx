import { useTranslation } from '@/contexts/TranslationContext';

interface Tour {
  id: string;
  name: string;
  mountain: string;
  date: string;
  status: 'completed' | 'upcoming';
}

interface TourListProps {
  tours: Tour[];
}

export default function TourList({ tours }: TourListProps) {
  const t = useTranslation();

  if (tours.length === 0) {
    return (
      <div className="text-center py-8 text-gray-500">{t.noToursFound}</div>
    );
  }

  return (
    <div className="space-y-3">
      {tours.map(tour => (
        <div
          key={tour.id}
          className="flex justify-between items-start p-4 bg-white border border-gray-200 rounded-lg shadow-sm"
        >
          <div className="flex-1">
            <h3 className="font-medium text-gray-900">{tour.name}</h3>
            <p className="text-sm text-gray-600 mt-1">
              {tour.mountain} • {tour.date}
            </p>
          </div>
          <span
            className={`px-3 py-1 text-xs font-medium rounded-full ${
              tour.status === 'completed'
                ? 'bg-green-100 text-green-800'
                : 'bg-blue-100 text-blue-800'
            }`}
          >
            {tour.status === 'completed' ? t.completed : t.upcoming}
          </span>
        </div>
      ))}
    </div>
  );
}
