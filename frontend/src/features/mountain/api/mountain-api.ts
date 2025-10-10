import { MOUNTAINS_ENDPOINTS } from './mountain-endpoints';
import { ViewMountainDto } from '../types';
import { axios_instance } from '@/lib/root-api';

export const getAllMountains = async (): Promise<ViewMountainDto[]> => {
  const response = await axios_instance.get<ViewMountainDto[]>(
    MOUNTAINS_ENDPOINTS.GET_ALL_MOUNTAINS
  );
  return response.data;
};
