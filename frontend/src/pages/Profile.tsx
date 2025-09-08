import HeaderTitle from '@/components/layout/HeaderTitle';
import { Tabs, TabsList, TabsTrigger, TabsContent } from '@/components/ui/tabs';
import { useTranslation } from '@/contexts/TranslationContext';
import ActivityStatsSummary from '@/features/profile/components/activityStatsSummary';
import UserSummary from '@/features/profile/components/userSummary';
import { ActivityStats } from '@/features/profile/types/activityStats';
import { User } from '@/features/profile/types/user';
import ReviewList from '@/features/review/components/reviewList';
import TourList from '@/features/tour/components/tourList';

const Profile = () => {
  const t = useTranslation();
  const user: User = {
    firstname: 'Ana',
    lastname: 'Novak',
    email: 'ana.novak@email.com',
    joinedOn: '6/15/2024',
    favoriteMountains: ['Triglav', 'Krn', 'Vogel'],
  };

  const stats: ActivityStats = {
    toursJoined: 8,
    reviewsWritten: 5,
    mountainsVisited: 3,
  };

  const tours = [
    {
      id: '1',
      name: 'Alpine Adventure: Triglav Summit',
      mountain: 'Triglav',
      date: '8/15/2024',
      status: 'completed' as const,
    },
    {
      id: '2',
      name: 'Krn Mountain Trail',
      mountain: 'Krn',
      date: '8/20/2024',
      status: 'upcoming' as const,
    },
  ];

  const reviews = [
    {
      id: '1',
      tourName: 'Alpine Adventure: Triglav Summit',
      mountain: 'Triglav',
      rating: 5,
      comment: 'Amazing experience with great guides and breathtaking views!',
      date: '8/16/2024',
    },
  ];

  return (
    <div className="flex flex-col">
      <HeaderTitle title={t.profile} subTitle={t.profileSubTitle} />

      <div className="flex gap-4 p-4">
        {/* Left Column - User Info & Stats */}
        <div className="flex flex-col gap-4">
          <UserSummary user={user} />
          <ActivityStatsSummary activityStats={stats} />
        </div>

        {/* Right Column - Tours & Reviews Tabs */}
        <div className="flex-1">
          <div className="bg-white rounded-lg border-[2px] border-black/20 shadow-lg p-6">
            <Tabs defaultValue="tours">
              <TabsList>
                <TabsTrigger value="tours">{t.myTours}</TabsTrigger>
                <TabsTrigger value="reviews">{t.myReviews}</TabsTrigger>
              </TabsList>
              <TabsContent value="tours">
                <TourList tours={tours} />
              </TabsContent>
              <TabsContent value="reviews">
                <ReviewList reviews={reviews} />
              </TabsContent>
            </Tabs>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
