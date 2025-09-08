export const en = {
  // Navigation
  home: 'Home',
  tours: 'Tours',
  mountains: 'Mountains',
  reviews: 'Reviews',
  notifications: 'Notifications',
  profile: 'My Profile',
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
  upcomingTours: 'Upcoming Tours',
  totalTours: 'Total Tours',
  addTour: 'Add Tour',
  tourPageTitle: 'Discover amazing mountain adventures and join fellow hikers',

  // Hero Section
  heroTitle: 'Discover',
  heroTitleGradient: 'Mountain Adventures',
  heroSubtitle:
    'Join fellow hikers on unforgettable journeys through most beautiful peaks. From gentle family trails to challenging summit conquests.',
  exploreTours: 'Explore Tours',
  viewMountains: 'View Mountains',

  // Profile
  profileSubTitle: 'Manage your account and view your hiking journey',
  activityStats: 'Activity Stats',
  toursJoined: 'Tours Joined',
  reviewsWritten: 'Reviews Written',
  mountainsVisited: 'Mountains Visited',
  email: 'Email',
  memberSince: 'Member since',

  // App summary
  activeTours: 'Active Tours',
  happyHikers: 'Happy Hikers',
  avgRating: 'Average Rating',

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
  totalMountains: 'Total mountains',
  upcoming: 'Upcoming',
  mountainsSubTitle: 'Explore the majestic peaks waiting to be conquered',

  // Status
  selectStatus: 'Select status',
  active: 'Active',
  reserved: 'Reserved',
  canceled: 'Canceled',

  // Add Mountain Dialog
  addNewMountain: 'Add New Mountain',
  mountainName: 'Mountain Name',
  mountainDescription: 'Mountain Description',
  mountainHeight: 'Height (meters)',
  mountainLocation: 'Location',
  cancel: 'Cancel',
  save: 'Save',
  enterMountainName: 'Enter mountain name',
  enterMountainDescription: 'Enter mountain description',
  enterMountainHeight: 'Enter height in meters',
  enterMountainLocation: 'Enter mountain location',

  // Add Tour Dialog
  tourName: 'Tour Name',
  selectMountainForTour: 'Select Mountain',
  enterTourName: 'Enter tour name',
  enterTourDescription: 'Enter tour description',
  enterMinPeople: 'Enter minimum number of people',
  enterMaxPeople: 'Enter maximum number of people',
  selectTourDate: 'Select tour date',

  // Misc
  searchTours: 'Search tours or mountains ...',
  searchMountains: 'Search mountains ...',
} as const;

export type Dictionary = typeof en;
