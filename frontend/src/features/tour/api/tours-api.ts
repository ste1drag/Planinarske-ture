import { TOURS_ENDPOINTS } from './endpoints';
import { axios_instance } from '../../../lib/root-api';
import { AddTourDto } from '../types/add-tour-dto';
import { DeleteTourDto } from '../types/delete-tour-dto';
import { TourViewModel } from '../types/tour-dto';

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

