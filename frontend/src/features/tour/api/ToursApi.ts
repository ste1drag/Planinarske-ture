import { TOURS_ENDPOINTS } from './TourEndpoints';
import { AddTourDto, AddTourCommand } from '../types/AddTourDto';
import { DeleteTourDto } from '../types/DeleteTourDto';
import { TourViewModel } from '../types/TourDto';
import { axios_instance } from '@/lib/root-api';
import { useAuthStore } from '@/features/auth/store/auth-store';

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

export const addTour = async (tourData: AddTourDto): Promise<void> => {
  const userId = useAuthStore.getState().user?.userId;
  if (!userId) {
    throw new Error('User must be authenticated to create a tour');
  }

  const command: AddTourCommand = {
    addTourDTO: tourData,
    createdBy: userId,
  };
  await axios_instance.post(TOURS_ENDPOINTS.ADD_TOUR, command);
};

export const deleteTour = async (tourData: DeleteTourDto): Promise<void> => {
  await axios_instance.delete(TOURS_ENDPOINTS.DELETE_TOUR, { data: tourData });
};

export const joinTour = async (tourId: string): Promise<void> => {
  await axios_instance.post(TOURS_ENDPOINTS.JOIN_TOUR(tourId));
};

export const cancelTour = async (tourId: string): Promise<void> => {
  await axios_instance.post(TOURS_ENDPOINTS.CANCEL_TOUR(tourId));
};
