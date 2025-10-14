import { useEffect, useMemo, useState } from 'react';
import HeaderTitle from '@/components/layout/HeaderTitle';
import { useTranslation } from '@/contexts/TranslationContext';
import { useAuthStore } from '@/features/auth/store/auth-store';
import UserSummary from '@/features/profile/components/userSummary';
import { ActivityStats } from '@/features/profile/types/activityStats';
import { User } from '@/features/profile/types/user';
import { getAllReviews } from '@/features/review/api/review-api';
import ReviewList from '@/features/review/components/reviewList';
import { ReadReviewDto } from '@/features/review/types/ReviewDto';

const Profile = () => {
  const t = useTranslation();
  const { user: authUser } = useAuthStore();
  const [reviews, setReviews] = useState<ReadReviewDto[]>([]);
  const [isLoadingReviews, setIsLoadingReviews] = useState(false);

  useEffect(() => {
    const fetchReviews = async () => {
      setIsLoadingReviews(true);
      try {
        const allReviews = await getAllReviews();
        console.log('Reviews data:', allReviews);
        setReviews(allReviews);
      } catch (error) {
        console.error('Error fetching reviews:', error);
      } finally {
        setIsLoadingReviews(false);
      }
    };

    fetchReviews();
  }, []);

  // Memoize random selection to persist during session
  const selectedReviews = useMemo(() => {
    if (reviews.length === 0) return [];
    const shuffled = [...reviews].sort(() => Math.random() - 0.5);
    return shuffled.slice(0, 5);
  }, [reviews]);

  const user: User = {
    firstname: authUser?.name.split(' ')[0] ?? '',
    lastname: authUser?.name.split(' ')[1] ?? '',
    email: authUser?.userName ?? '',
    joinedOn: '',
    favoriteMountains: [],
  };

  const stats: ActivityStats = {
    toursJoined: 0,
    reviewsWritten: reviews.length,
    mountainsVisited: 0,
  };

  const transformedReviews = selectedReviews.map(review => {
    // Generate random rating (1-5) if score is not available
    const rating = review.score ?? Math.floor(Math.random() * 5) + 1;

    return {
      id: review.id.toString(),
      tourName: review.title,
      mountain: '',
      rating,
      comment: review.comment ?? '',
      date: new Date(review.createdDate).toLocaleDateString(),
    };
  });

  return (
    <div className="flex flex-col">
      <HeaderTitle title={t.profile} subTitle={t.profileSubTitle} />

      <div className="flex gap-4 p-4">
        <div className="flex flex-col gap-4">
          <UserSummary user={user} />
        </div>
        <div className="flex-1">
          <div className="bg-white rounded-lg border-[2px] border-black/20 shadow-lg p-6">
            <h2 className="text-xl font-semibold mb-4">{t.myReviews}</h2>
            {isLoadingReviews ? (
              <div className="text-center py-8 text-gray-500">Loading...</div>
            ) : (
              <ReviewList reviews={transformedReviews} />
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
