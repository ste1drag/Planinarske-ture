import { MOUNTAINS_ENDPOINTS } from './mountain-endpoints';
import { axios_instance } from '@/lib/root-api';
import { MountainDto } from '../types/mountain-dto';

export const getAllMountains = async (): Promise<MountainDto[]> => {
  const response = await axios_instance.get<MountainDto[]>(
    MOUNTAINS_ENDPOINTS.GET_ALL_MOUNTAINS
  );
  return response.data;
};
