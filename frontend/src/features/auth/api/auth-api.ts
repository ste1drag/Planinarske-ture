import { AUTH_ENDPOINTS } from './auth-endpoints';
import {
  NewUserDTO,
  UserCredentialsDTO,
  AuthenticationModel,
  RefreshTokenModel,
} from '../types/auth-types';
import { axios_instance } from '@/lib/root-api';

export const registerUser = async (userData: NewUserDTO): Promise<void> => {
  await axios_instance.post(AUTH_ENDPOINTS.REGISTER_USER, userData);
};

export const loginUser = async (
  credentials: UserCredentialsDTO
): Promise<AuthenticationModel> => {
  const response = await axios_instance.post<AuthenticationModel>(
    AUTH_ENDPOINTS.LOGIN,
    credentials
  );
  return response.data;
};

export const logoutUser = async (
  refreshData: RefreshTokenModel
): Promise<void> => {
  await axios_instance.post(AUTH_ENDPOINTS.LOGOUT, refreshData);
};

export const refreshToken = async (
  refreshData: RefreshTokenModel
): Promise<AuthenticationModel> => {
  const response = await axios_instance.post<AuthenticationModel>(
    AUTH_ENDPOINTS.REFRESH_TOKEN,
    refreshData
  );
  return response.data;
};
