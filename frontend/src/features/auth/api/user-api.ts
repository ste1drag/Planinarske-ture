import { AUTH_ENDPOINTS } from './auth-endpoints';
import { UserDetailsDTO } from '../types/auth-types';
import { axios_instance } from '@/lib/root-api';

export const getAllUsers = async (): Promise<UserDetailsDTO[]> => {
  const response = await axios_instance.get<UserDetailsDTO[]>(
    AUTH_ENDPOINTS.GET_ALL_USERS
  );
  return response.data;
};

export const assignTourGuideRole = async (userId: string): Promise<void> => {
  await axios_instance.post(AUTH_ENDPOINTS.ASSIGN_TOUR_GUIDE(userId));
};
