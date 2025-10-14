import { Calendar, Star, Plus } from 'lucide-react';
import { useEffect, useState } from 'react';
import StatusBadge from './StatusBadge';
import WeatherBadge from './WeatherBadge';
import { TourStatus } from '../enums/TourStatus';
import { TourViewModel } from '../types/TourDto';
import { Button } from '@/components/ui/Button';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from '@/components/ui/Dialog';
import { useTranslation } from '@/contexts/TranslationContext';
import {
  getReviewsByTourId,
  createReview,
} from '@/features/review/api/review-api';
import CreateReviewForm from '@/features/review/components/CreateReviewForm';
import {
  ReadReviewDto,
  CreateReviewDto,
} from '@/features/review/types/ReviewDto';

interface TourDetailsDialogProps {
  tour: TourViewModel | null;
  open: boolean;
  onClose: () => void;
}

export default function TourDetailsDialog({
  tour,
  open,
  onClose,
}: TourDetailsDialogProps) {
  const t = useTranslation();
  const [reviews, setReviews] = useState<ReadReviewDto[]>([]);
  const [isLoadingReviews, setIsLoadingReviews] = useState(false);
  const [showReviewForm, setShowReviewForm] = useState(false);
  const [currentUserId] = useState(1);

  const loadReviews = () => {
    if (tour) {
      setIsLoadingReviews(true);
      getReviewsByTourId(tour.id)
        .then(data => {
          // Generate random review scores (1-5) if not available
          const reviewsWithScores = data.map(review => ({
            ...review,
            score: review.score ?? Math.floor(Math.random() * 5) + 1,
          }));
          setReviews(reviewsWithScores);
        })
        .catch(error => {
          console.error('Failed to fetch reviews:', error);
          setReviews([]);
        })
        .finally(() => {
          setIsLoadingReviews(false);
        });
    }
  };

  useEffect(() => {
    if (open && tour) {
      loadReviews();
      setShowReviewForm(false);
    }
  }, [open, tour]);

  const handleSubmitReview = async (reviewData: CreateReviewDto) => {
    try {
      await createReview(reviewData);
      setShowReviewForm(false);
      loadReviews();
    } catch (error) {
      console.error('Failed to create review:', error);
      throw error;
    }
  };

  if (!tour) return null;

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    };
    return date.toLocaleDateString('en-US', options);
  };

  const formatReviewDate = (dateString: string) => {
    const date = new Date(dateString);
    return date.toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
    });
  };

  const averageRating =
    reviews.length > 0
      ? reviews.reduce((sum, review) => sum + (review.score ?? 0), 0) /
        reviews.length
      : 0;

  const canWriteReview = tour.status === TourStatus.COMPLETED;

  return (
    <Dialog open={open} onOpenChange={onClose}>
      <DialogContent className="max-w-3xl max-h-[90vh] overflow-y-auto">
        <DialogHeader>
          <DialogTitle className="text-2xl font-bold text-forest mb-3">
            {tour.name}
          </DialogTitle>
          <div className="flex gap-2">
            <StatusBadge tourStatus={tour.status} />
            <WeatherBadge weather={tour.weather} />
          </div>
        </DialogHeader>

        <div className="space-y-6">
          {/* Tour Details */}
          <div className="space-y-3">
            <div className="flex items-center gap-2 text-muted-foreground">
              <Calendar className="h-5 w-5" />
              <span>{formatDate(tour.date)}</span>
            </div>
          </div>

          {/* Description */}
          <div>
            <h3 className="text-lg font-semibold mb-2">Description</h3>
            <p className="text-muted-foreground">{tour.description}</p>
          </div>

          {/* Reviews Section */}
          <div>
            <div className="flex items-center justify-between mb-4">
              <h3 className="text-lg font-semibold">
                Reviews ({reviews.length})
              </h3>
              <div className="flex items-center gap-3">
                {reviews.length > 0 && (
                  <div className="flex items-center gap-2">
                    <Star className="h-5 w-5 fill-yellow-500 text-yellow-500" />
                    <span className="font-semibold">
                      {averageRating.toFixed(1)}
                    </span>
                    <span className="text-muted-foreground text-sm">/ 5.0</span>
                  </div>
                )}
                {!showReviewForm && canWriteReview && (
                  <Button
                    size="sm"
                    onClick={() => setShowReviewForm(true)}
                    className="flex items-center gap-2"
                  >
                    <Plus className="h-4 w-4" />
                    Write Review
                  </Button>
                )}
                {!canWriteReview && (
                  <p className="text-sm text-muted-foreground italic">
                    Reviews can only be written for completed tours
                  </p>
                )}
              </div>
            </div>

            {showReviewForm && (
              <div className="mb-6 p-4 border border-gray-200 rounded-lg bg-gray-50">
                <h4 className="text-md font-semibold mb-4">Write a Review</h4>
                <CreateReviewForm
                  tourId={tour.id}
                  userId={currentUserId}
                  onSubmit={handleSubmitReview}
                  onCancel={() => setShowReviewForm(false)}
                />
              </div>
            )}

            <div className="space-y-4">
              {isLoadingReviews ? (
                <p className="text-center py-8 text-muted-foreground">
                  Loading reviews...
                </p>
              ) : reviews.length === 0 ? (
                <p className="text-center py-8 text-muted-foreground">
                  No reviews yet. Be the first to review this tour!
                </p>
              ) : (
                reviews.map(review => (
                  <div
                    key={review.id}
                    className="border border-gray-200 rounded-lg p-4 space-y-2"
                  >
                    <div className="flex items-center justify-between">
                      <div className="flex items-center gap-2">
                        <div className="h-10 w-10 rounded-full bg-forest-light flex items-center justify-center text-white font-semibold">
                          U{review.userId}
                        </div>
                        <div>
                          <p className="font-semibold">{review.title}</p>
                          <p className="text-sm text-muted-foreground">
                            {formatReviewDate(review.createdDate)}
                          </p>
                        </div>
                      </div>
                      <div className="flex items-center gap-1">
                        {[...Array(5)].map((_, i) => (
                          <Star
                            key={i}
                            className={`h-4 w-4 ${
                              i < (review.score || 0)
                                ? 'fill-yellow-500 text-yellow-500'
                                : 'text-gray-300'
                            }`}
                          />
                        ))}
                      </div>
                    </div>
                    {review.comment && (
                      <p className="text-muted-foreground">{review.comment}</p>
                    )}
                    {review.difficulty !== null &&
                      review.difficulty !== undefined && (
                        <p className="text-sm text-muted-foreground">
                          Difficulty: {review.difficulty}/5
                        </p>
                      )}
                  </div>
                ))
              )}
            </div>
          </div>
        </div>
      </DialogContent>
    </Dialog>
  );
}
