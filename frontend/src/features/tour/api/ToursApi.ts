import { TOURS_ENDPOINTS } from './TourEndpoints';
import { axios_instance } from '../../../lib/root-api';
import { AddTourDto } from '../types/AddTourDto';
import { DeleteTourDto } from '../types/DeleteTourDto';
import { TourViewModel } from '../types/TourDto';

export const getAllTours = async (): Promise<TourViewModel[]> => {
  const response = await axios_instance.get<TourViewModel[]>(
    TOURS_ENDPOINTS.GET_ALL_TOURS
  );
  return response.data;
};

export const getTourById = async (tourId: string): Promise<TourViewModel> => {
  const response = await axios_instance.get<TourViewModel>(
    TOURS_ENDPOINTS.GET_TOUR_BY_ID(tourId)
  );
  return response.data;
};

export const getToursByMountainId = async (
  mountainId: string
): Promise<TourViewModel[]> => {
  const response = await axios_instance.get<TourViewModel[]>(
    TOURS_ENDPOINTS.GET_TOURS_BY_MOUNTAIN_ID(mountainId)
  );
  return response.data;
};

export const addTour = async (tourData: AddTourDto): Promise<TourViewModel> => {
  const response = await axios_instance.post<TourViewModel>(
    TOURS_ENDPOINTS.ADD_TOUR,
    tourData
  );
  return response.data;
};

export const deleteTour = async (tourData: DeleteTourDto): Promise<void> => {
  await axios_instance.delete(TOURS_ENDPOINTS.DELETE_TOUR, { data: tourData });
};
