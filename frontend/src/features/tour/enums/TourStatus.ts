export enum TourStatus {
  ACTIVE = 0,
  RESERVED = 1,
  CANCELED = 2,
  COMPLETED = 3,
}

export const TourStatusLabels: Record<TourStatus, string> = {
  [TourStatus.ACTIVE]: 'ACTIVE',
  [TourStatus.RESERVED]: 'RESERVED',
  [TourStatus.CANCELED]: 'CANCELED',
  [TourStatus.COMPLETED]: 'COMPLETED',
};

export const TourStatusColoring: Record<TourStatus, string> = {
  [TourStatus.ACTIVE]: '#66FF66',
  [TourStatus.RESERVED]: '#D2A679',
  [TourStatus.CANCELED]: '#FF6666',
  [TourStatus.COMPLETED]: '#4A90E2',
};
