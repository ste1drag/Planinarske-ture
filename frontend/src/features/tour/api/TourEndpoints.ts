export const TOURS_ENDPOINTS = {
  GET_ALL_TOURS: '/tours-api/Tours',
  GET_TOUR_BY_ID: (tourId: string) => `/tours-api/Tours/${tourId}`,
  GET_TOURS_BY_MOUNTAIN_ID: (mountainId: string) =>
    `/tours-api/Tours/${mountainId}/tours`,
  ADD_TOUR: '/tours-api/Tours',
  DELETE_TOUR: '/tours-api/Tours',
} as const;
