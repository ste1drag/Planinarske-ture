export enum TourStatus {
  ACTIVE = 0,
  RESERVED = 1,
  CANCELED = 2,
}

export const TourStatusLabels: Record<TourStatus, string> = {
  [TourStatus.ACTIVE]: 'ACTIVE',
  [TourStatus.RESERVED]: 'RESERVED',
  [TourStatus.CANCELED]: 'CANCELED',
};

export const TourStatusColoring: Record<TourStatus, string> = {
  [TourStatus.ACTIVE]: '#66FF66',
  [TourStatus.RESERVED]: '#D2A679',
  [TourStatus.CANCELED]: '#FF6666',
};
