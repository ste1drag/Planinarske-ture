export const en = {
  // Navigation
  home: 'Home',
  tours: 'Tours',
  mountains: 'Mountains',
  reviews: 'Reviews',
  notifications: 'Notifications',
  profile: 'Profile',
  mountainTours: 'Mountain Tours',
  hikingTours: 'Hiking Tours',

  // Form labels
  name: 'Name',
  mountain: 'Mountain',
  selectMountain: 'Select a mountain',
  minPeople: 'Minimum number of people',
  maxPeople: 'Maximum number of people',
  tourDescription: 'Tour Description',
  tourDate: 'Tour Date',

  // Tours
  addNewTour: 'Add New Tour',
  addTour: 'Add Tour',
  tourPageTitle: 'Discover amazing mountain adventures and join fellow hikers',

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
  addMountainButton: 'Add Mountain',

  // Mountain
  totalHours: 'Total hours',
  upcoming: 'Upcoming',
  mountainsSubTitle: 'Explore the majestic peaks waiting to be conquered',
} as const;

export type Dictionary = typeof en;
