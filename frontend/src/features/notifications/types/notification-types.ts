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
  userId: string;
  type: NotificationType;
  title: string;
  message: string;
  status: NotificationStatus;
  createdAt: string;
  readAt?: string;
  relatedEntityId?: string;
  relatedEntityType?: string;
  content?: Record<string, any>;
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
