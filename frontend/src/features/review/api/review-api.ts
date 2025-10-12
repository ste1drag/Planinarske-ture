import { REVIEW_ENDPOINTS } from './review-endpoints';
import { ReadReviewDto } from '../types/ReviewDto';
import { axios_instance } from '@/lib/root-api';

export const getAllReviews = async (): Promise<ReadReviewDto[]> => {
  const response = await axios_instance.get<ReadReviewDto[]>(
    REVIEW_ENDPOINTS.GET_ALL_REVIEWS
  );
  return response.data;
};

export const getReviewById = async (id: number): Promise<ReadReviewDto> => {
  const response = await axios_instance.get<ReadReviewDto>(
    REVIEW_ENDPOINTS.GET_REVIEW_BY_ID(id)
  );
  return response.data;
};

export const getReviewsByTourId = async (
  tourId: string
): Promise<ReadReviewDto[]> => {
  const allReviews = await getAllReviews();
  return allReviews.filter(review => review.tourId.toString() === tourId);
};
