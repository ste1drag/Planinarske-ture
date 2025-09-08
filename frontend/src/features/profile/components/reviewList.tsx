import { useTranslation } from '@/contexts/TranslationContext';
import { Review } from '@/features/review/types/review';

interface ReviewListProps {
  reviews: Review[];
}

export default function ReviewList({ reviews }: ReviewListProps) {
  const t = useTranslation();

  if (reviews.length === 0) {
    return (
      <div className="text-center py-8 text-gray-500">{t.noReviewsFound}</div>
    );
  }

  const renderStars = (rating: number) => {
    return Array.from({ length: 5 }, (_, i) => (
      <span
        key={i}
        className={`text-sm ${
          i < rating ? 'text-yellow-400' : 'text-gray-300'
        }`}
      >
        ★
      </span>
    ));
  };

  return (
    <div className="space-y-3">
      {reviews.map(review => (
        <div
          key={review.id}
          className="p-4 bg-white border border-gray-200 rounded-lg shadow-sm"
        >
          <div className="flex justify-between items-start mb-2">
            <h3 className="font-medium text-gray-900">{review.tourName}</h3>
            <span className="text-xs text-gray-500">{review.date}</span>
          </div>
          <p className="text-sm text-gray-600 mb-2">{review.mountain}</p>
          <div className="flex items-center mb-2">
            {renderStars(review.rating)}
            <span className="ml-2 text-sm text-gray-600">
              ({review.rating}/5)
            </span>
          </div>
          <p className="text-sm text-gray-700">{review.comment}</p>
        </div>
      ))}
    </div>
  );
}
