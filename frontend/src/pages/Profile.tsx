import HeaderTitle from '@/components/layout/HeaderTitle';
import { useTranslation } from '@/contexts/TranslationContext';
import ActivityStatsSummary from '@/features/profile/components/activityStatsSummary';
import UserSummary from '@/features/profile/components/userSummary';
import { ActivityStats } from '@/features/profile/types/activityStats';
import { User } from '@/features/profile/types/user';

const Profile = () => {
  const t = useTranslation();
  const user: User = {
    firstname: 'Pavle',
    lastname: 'Vlajkovic',
    email: 'vlajkovicpavle@gmail.com',
    joinedOn: '10.02.2005',
  };

  const stats: ActivityStats = {
    toursJoined: 0,
    reviewsWritten: 0,
    mountainsVisited: 0,
  };

  return (
    <div className="flex flex-col">
      <HeaderTitle title={t.profile} subTitle={t.profileSubTitle} />
      <UserSummary user={user} />
      <ActivityStatsSummary activityStats={stats} />
    </div>
  );
};

export default Profile;
