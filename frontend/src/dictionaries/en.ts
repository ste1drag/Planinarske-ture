export const en = {
  // Navigation
  home: 'Home',
  tours: 'Tours',
  mountains: 'Mountains',
  reviews: 'Reviews',
  notifications: 'Notifications',
  profile: 'Profile',
  addTour: 'Add Tour',
  mountainTours: 'Mountain Tours',

  // Form labels
  name: 'Name',
  mountain: 'Mountain',
  selectMountain: 'Select a mountain',
  minPeople: 'Minimum number of people',
  maxPeople: 'Maximum number of people',
  tourDescription: 'Tour Description',
  tourDate: 'Tour Date',

  // Page titles
  addNewTour: 'Add New Tour',

  // Buttons
  addTourButton: 'Add Tour',
} as const;

export type Dictionary = typeof en;
