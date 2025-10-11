import { create } from 'zustand';
import {
  loginUser,
  registerUser,
  logoutUser,
  refreshToken,
} from '../api/auth-api';
import {
  AuthenticationModel,
  NewUserDTO,
  UserCredentialsDTO,
} from '../types/auth-types';

interface AuthStore {
  user: AuthenticationModel | null;
  isLoading: boolean;
  error: string | null;
  login: (credentials: UserCredentialsDTO) => Promise<void>;
  register: (userData: NewUserDTO) => Promise<void>;
  logout: () => Promise<void>;
  refresh: () => Promise<void>;
  clearError: () => void;
  initializeAuth: () => void;
}

export const useAuthStore = create<AuthStore>((set, get) => ({
  user: null,
  isLoading: false,
  error: null,
  login: async credentials => {
    set({ isLoading: true, error: null });
    try {
      const authData = await loginUser(credentials);
      console.log(authData);
      localStorage.setItem('name', authData.userName);
      localStorage.setItem('auth_token', authData.accessToken);
      localStorage.setItem('refresh_token', authData.refreshToken);
      localStorage.setItem('user_name', authData.userName);
      set({ user: authData, isLoading: false });
    } catch (error) {
      // prefer server message when available
      const serverMessage = (error as any)?.response?.data?.message;
      set({
        error: serverMessage ?? 'Login failed',
        isLoading: false,
      });
    }
  },

  register: async userData => {
    set({ isLoading: true, error: null });
    try {
      await registerUser(userData);
      set({ isLoading: false });
    } catch (error) {
      const serverMessage = (error as any)?.response?.data?.message;
      set({
        error: serverMessage ?? (error instanceof Error ? error.message : 'Registration failed'),
        isLoading: false,
      });
    }
  },

  logout: async () => {
    const { user } = get();
    if (user) {
      const userName = localStorage.getItem('user_name');
      if (userName) {
        try {
          await logoutUser({
            UserName: userName,
            RefreshToken: user.refreshToken,
          });
        } catch (error) {
          console.error('Logout API call failed:', error);
        }
      }
    }

    localStorage.removeItem('auth_token');
    localStorage.removeItem('refresh_token');
    localStorage.removeItem('user_name');
    set({ user: null, error: null });
  },

  refresh: async () => {
    const refreshTokenValue = localStorage.getItem('refresh_token');
    const userName = localStorage.getItem('user_name');
    if (!refreshTokenValue || !userName) {
      set({ user: null });
      return;
    }
    try {
      const authData = await refreshToken({
        UserName: userName,
        RefreshToken: refreshTokenValue,
      });
      localStorage.setItem('auth_token', authData.accessToken);
      localStorage.setItem('refresh_token', authData.refreshToken);
      set({ user: authData });
    } catch (error) {
      localStorage.removeItem('auth_token');
      localStorage.removeItem('refresh_token');
      localStorage.removeItem('user_name');
      localStorage.removeItem('name');
      set({ user: null });
    }
  },

  clearError: () => set({ error: null }),
  initializeAuth: () => {
    const token = localStorage.getItem('auth_token');
    const refreshTokenValue = localStorage.getItem('refresh_token');
    const name = localStorage.getItem('name');
    const username = localStorage.getItem('user_name');
    if (token && refreshTokenValue && name && username) {
      set({
        user: {
          accessToken: token,
          refreshToken: refreshTokenValue,
          isAuthorized: true,
          name: name,
          userName: username
        },
      });
    }
  },
}));
