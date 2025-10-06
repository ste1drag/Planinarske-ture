export enum TourStatus {
  ACTIVE = 'ACTIVE',
  RESERVED = 'RESERVED',
  CANCELED = 'CANCELED',
}

export const TourStatusColoring: Record<TourStatus, string> = {
  [TourStatus.ACTIVE]: '#66FF66',
  [TourStatus.RESERVED]: '#D2A679',
  [TourStatus.CANCELED]: '#FF6666',
};
