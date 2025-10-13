const REVIEWING_API_BASE_URL = '/reviewing-api';

export const REVIEW_ENDPOINTS = {
  GET_ALL_REVIEWS: `${REVIEWING_API_BASE_URL}/api/Reviews`,
  GET_REVIEW_BY_ID: (id: number) =>
    `${REVIEWING_API_BASE_URL}/api/Reviews/${id}`,
  GET_REVIEWS_BY_TOUR_ID: (tourId: string) =>
    `${REVIEWING_API_BASE_URL}/api/Reviews/tour/${tourId}`,
  CREATE_REVIEW: `${REVIEWING_API_BASE_URL}/api/Reviews`,
} as const;
