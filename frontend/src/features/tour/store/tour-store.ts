import { create } from 'zustand';
import {
  getAllTours,
  getTourById,
  getToursByMountainId,
  addTour,
  deleteTour,
} from '../api/ToursApi';
import { TourViewModel, AddTourDto, DeleteTourDto } from '../types';

interface TourStore {
  tours: TourViewModel[];
  selectedTour: TourViewModel | null;
  isLoading: boolean;
  error: string | null;
  fetchAllTours: () => Promise<void>;
  fetchTourById: (tourId: string) => Promise<void>;
  fetchToursByMountainId: (mountainId: string) => Promise<void>;
  createTour: (tourData: AddTourDto) => Promise<void>;
  removeTour: (tourData: DeleteTourDto) => Promise<void>;
  selectTour: (tour: TourViewModel) => void;
  clearSelection: () => void;
  clearError: () => void;
}

export const useTourStore = create<TourStore>((set, get) => ({
  tours: [],
  selectedTour: null,
  isLoading: false,
  error: null,

  fetchAllTours: async () => {
    set({ isLoading: true, error: null });
    try {
      const tours = await getAllTours();
      set({ tours, isLoading: false });
    } catch (error) {
      set({
        error: error instanceof Error ? error.message : 'Failed to fetch tours',
        isLoading: false,
      });
    }
  },

  fetchTourById: async (tourId: string) => {
    set({ isLoading: true, error: null });
    try {
      const tour = await getTourById(tourId);
      set({ selectedTour: tour, isLoading: false });
    } catch (error) {
      set({
        error: error instanceof Error ? error.message : 'Failed to fetch tour',
        isLoading: false,
      });
    }
  },

  fetchToursByMountainId: async (mountainId: string) => {
    set({ isLoading: true, error: null });
    try {
      const tours = await getToursByMountainId(mountainId);
      set({ tours, isLoading: false });
    } catch (error) {
      set({
        error:
          error instanceof Error
            ? error.message
            : 'Failed to fetch tours for mountain',
        isLoading: false,
      });
    }
  },

  createTour: async (tourData: AddTourDto) => {
    set({ isLoading: true, error: null });
    try {
      await addTour(tourData);
      await get().fetchAllTours();
    } catch (error) {
      set({
        error: error instanceof Error ? error.message : 'Failed to create tour',
        isLoading: false,
      });
    }
  },

  removeTour: async (tourData: DeleteTourDto) => {
    set({ isLoading: true, error: null });
    try {
      await deleteTour(tourData);
      const { tours } = get();
      const updatedTours = tours.filter(tour => tour.id !== tourData.tourId);
      set({ tours: updatedTours, isLoading: false });
    } catch (error) {
      set({
        error: error instanceof Error ? error.message : 'Failed to delete tour',
        isLoading: false,
      });
    }
  },

  selectTour: (tour: TourViewModel) => {
    set({ selectedTour: tour });
  },

  clearSelection: () => {
    set({ selectedTour: null });
  },

  clearError: () => set({ error: null }),
}));
