import { User } from '../types/user';
import { useTranslation } from '@/contexts/TranslationContext';

export default function UserSummary({ user }: { user: User }) {
  const t = useTranslation();

  return (
    <div className="flex flex-col border-[2px] border-black/20 w-full p-4 shadow-lg bg-white rounded-lg">
      <h2 className="text-lg font-medium mb-4 text-gray-700">
        {user.firstname} {user.lastname}
      </h2>
      <hr className="pb-2" />

      <div className="mb-3">
        <span className="text-gray-600">{t.email}</span>
        <div className="font-medium">{user.email}</div>
      </div>

      <div>
        <span className="text-gray-600">{t.memberSince}</span>
        <div className="font-medium">{user.joinedOn}</div>
      </div>
    </div>
  );
}
