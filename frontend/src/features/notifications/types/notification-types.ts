export enum NotificationType {
  TourCreated = 'TourCreated',
  TourUpdated = 'TourUpdated',
  TourDeleted = 'TourDeleted',
  ReviewCreated = 'ReviewCreated',
  ReviewUpdated = 'ReviewUpdated',
  MountainAdded = 'MountainAdded',
}

export enum NotificationStatus {
  Unread = 'Unread',
  Read = 'Read',
  Deleted = 'Deleted',
}

export interface InAppNotificationResponse {
  id: string;
  tourId: string;
  type: number;
  title: string;
  descriptionOfTour: string;
  content: string;
  status: string;
  occuredOn: string;
  createdAt?: string;
  sentAt?: string;
  readAt?: string;
}

export interface NotificationFilters {
  status?: NotificationStatus;
  type?: NotificationType;
  limit?: number;
  offset?: number;
}

export interface NotificationStats {
  unreadCount: number;
  totalCount: number;
}
