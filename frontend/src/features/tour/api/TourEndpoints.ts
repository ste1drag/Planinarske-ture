// Tours endpoints (standardized)
export const TOURS_ENDPOINTS = {
  GET_ALL_TOURS: '/api/tours',
  GET_TOUR_BY_ID: (tourId: string) => `/api/tours/${tourId}`,
  GET_TOURS_BY_MOUNTAIN_ID: (mountainId: string) =>
    `/api/tours/${mountainId}/tours`,
  ADD_TOUR: '/api/tours',
  DELETE_TOUR: '/api/tours',
} as const;
