import { ActivityStats } from '../types/activityStats';
import { useTranslation } from '@/contexts/TranslationContext';

export default function ActivityStatsSummary({
  activityStats,
}: {
  activityStats: ActivityStats;
}) {
  const t = useTranslation();
  return (
    <div className="flex flex-col border-[2px] border-black/20 max-w-[30vh] p-4 shadow-lg bg-white rounded-lg">
      <h2 className="text-lg font-medium mb-4 text-gray-700">
        {t.activityStats}
      </h2>
      <hr className="pb-2" />
      <div className="flex items-center justify-between mb-3">
        <div className="flex items-center gap-2">
          <div className="w-4 h-4 bg-green-500 rounded-sm"></div>
          <span className="text-gray-600">{t.toursJoined}</span>
        </div>
        <span className="font-medium pl-4">
          {activityStats?.toursJoined ?? 0}
        </span>
      </div>
      <div className="flex items-center justify-between mb-3">
        <div className="flex items-center gap-2">
          <div className="w-4 h-4 bg-blue-500 rounded-sm"></div>
          <span className="text-gray-600">{t.reviewsWritten}</span>
        </div>
        <span className="font-medium pl-4">
          {activityStats?.reviewsWritten ?? 0}
        </span>
      </div>
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-2">
          <div className="w-4 h-4 bg-orange-500 rounded-sm"></div>
          <span className="text-gray-600">{t.mountainsVisited}</span>
        </div>
        <span className="font-medium pl-4">
          {activityStats?.mountainsVisited ?? 0}
        </span>
      </div>
    </div>
  );
}
