export const TOURS_ENDPOINTS = {
  GET_ALL_TOURS: '/Tours',
  GET_TOUR_BY_ID: (tourId: string) => `/Tours/${tourId}`,
  GET_TOURS_BY_MOUNTAIN_ID: (mountainId: string) =>
    `/Tours/${mountainId}/tours`,
  ADD_TOUR: '/Tours',
  DELETE_TOUR: '/Tours',
} as const;
