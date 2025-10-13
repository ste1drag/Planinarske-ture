import { REVIEW_ENDPOINTS } from './review-endpoints';
import { ReadReviewDto, CreateReviewDto } from '../types/ReviewDto';
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
  const response = await axios_instance.get<ReadReviewDto[]>(
    REVIEW_ENDPOINTS.GET_REVIEWS_BY_TOUR_ID(tourId)
  );
  return response.data;
};

export const createReview = async (
  reviewData: CreateReviewDto
): Promise<ReadReviewDto> => {
  const response = await axios_instance.post<ReadReviewDto>(
    REVIEW_ENDPOINTS.CREATE_REVIEW,
    reviewData
  );
  return response.data;
};
