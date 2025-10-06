import { create } from 'zustand';
import { getAllMountains } from '../api/mountain-api';
import { ViewMountainDto } from '../types';

interface MountainStore {
  mountains: ViewMountainDto[];
  selectedMountain: ViewMountainDto | null;
  isLoading: boolean;
  error: string | null;
  lastFetched: number | null;
  fetchMountains: (force?: boolean) => Promise<void>;
  getMountains: () => Promise<ViewMountainDto[]>;
  selectMountain: (mountain: ViewMountainDto) => void;
  clearSelection: () => void;
  clearError: () => void;
}

export const useMountainStore = create<MountainStore>((set, get) => ({
  mountains: [],
  selectedMountain: null,
  isLoading: false,
  error: null,
  lastFetched: null,

  fetchMountains: async (force = false) => {
    const { mountains, lastFetched, isLoading } = get();

    if (isLoading) return;
    const CACHE_DURATION = 5 * 60 * 1000; // 5 minutes
    if (
      !force &&
      mountains.length > 0 &&
      lastFetched &&
      Date.now() - lastFetched < CACHE_DURATION
    ) {
      return;
    }

    set({ isLoading: true, error: null });
    try {
      const fetchedMountains = await getAllMountains();
      set({
        mountains: fetchedMountains,
        isLoading: false,
        lastFetched: Date.now(),
      });
    } catch (error) {
      set({
        error:
          error instanceof Error ? error.message : 'Failed to fetch mountains',
        isLoading: false,
      });
    }
  },

  getMountains: async () => {
    await get().fetchMountains();
    return get().mountains;
  },

  selectMountain: (mountain: ViewMountainDto) => {
    set({ selectedMountain: mountain });
  },

  clearSelection: () => {
    set({ selectedMountain: null });
  },

  clearError: () => set({ error: null }),
}));
