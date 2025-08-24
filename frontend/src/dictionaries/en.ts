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

  // Hero Section
  heroTitle: 'Discover',
  heroTitleGradient: 'Mountain Adventures',
  heroSubtitle:
    'Join fellow hikers on unforgettable journeys through most beautiful peaks. From gentle family trails to challenging summit conquests.',
  exploreTours: 'Explore Tours',
  viewMountains: 'View Mountains',

  // CTA Section
  readyForAdventure: 'Ready for Your Next Adventure?',
  joinCommunity:
    'Join our community of mountain enthusiasts and discover the beauty of peaks',
  joinTour: 'Join Tour',
  readReviews: 'Read Reviews',

  // Buttons
  addTourButton: 'Add Tour',
} as const;

export type Dictionary = typeof en;
