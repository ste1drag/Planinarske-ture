import { TourStatus, TourStatusColoring } from '../enums/TourStatus';
import GenericBadge from '@/components/ui/GenericCardBadge';

export default function StatusBadge({
  tourStatus,
}: {
  tourStatus: TourStatus;
}) {
  const backgroundColor = TourStatusColoring[tourStatus];

  return (
    <GenericBadge
      value={tourStatus}
      label={TourStatus[tourStatus]}
      colorMap={TourStatusColoring}
      style={{
        backgroundColor,
        color: 'white',
        border: 'none',
      }}
    />
  );
}
